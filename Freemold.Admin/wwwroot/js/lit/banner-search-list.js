import { LitElement, html } from "../vendor/lit.js";

class BannerSearchList extends LitElement {

    static properties = {
        searchtype: { state: true },
        companyname: { state: true },
        searchfree: { state: true },
        items: { state: true },
        loading: { state: true },
        error: { state: true },
        page: { state: true },
        pagesize: { state: true },
        totalCount: { state: true }
    };

    constructor() {
        super();
        this.searchtype = "";
        this.companyname = "";
        this.searchfree = "";
        this.items = [];
        this.loading = false;
        this.error = "";
        this.requestController = null;
        this.page = 1;          // 현재 페이지
        this.pagesize = 20;     // 한 페이지당 10개
        this.totalCount = 0;    // 전체 데이터 건수
    }

    createRenderRoot() {
        return this;
    }

    // 화면에 컴포넌트가 연결되면 실행
    connectedCallback() {
        super.connectedCallback();
        this.getBannerList();
    }

    // 배너 목록 가져오기
    async getBannerList() {

        if (this.requestController) {
            this.requestController.abort();
        }

        const controller = new AbortController();
        this.requestController = controller;

        this.loading = true;
        this.error = "";

        try {
            
            const params = new URLSearchParams({
                page: this.page,
                pagesize: this.pagesize,
                searchtype: this.searchtype,
                companyname: this.companyname,
                searchfree: this.searchfree
            });

            const response = await fetch("/Banner/AjaxGetSearchBanner",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded"
                    },
                    body: params,
                    signal: controller.signal
                }
            );

            if (!response.ok) {
                throw new Error("배너 목록 조회 실패");
            }

            const data = await response.json();

            this.items = data.items ?? [];
            this.totalCount = data.totalCount ?? 0;

        } catch (err) {

            if (err.name !== "AbortError") {
                this.error = err.message;
            }

        } finally {

            if (this.requestController === controller) {
                this.loading = false;
                this.requestController = null;
            }
        }
    }

    disconnectedCallback() {
        super.disconnectedCallback();
        this.requestController?.abort();
    }

    renderRows() {

        if (this.loading) {
            return html`
                <tr>
                    <td colspan="10" class="text-center py-4">
                        데이터를 조회하고 있습니다.
                    </td>
                </tr>
            `;
        }

        if (this.error) {
            return html`
                <tr>
                    <td colspan="10" class="text-center text-danger py-4">
                        ${this.error}
                    </td>
                </tr>
            `;
        }

        if (this.items.length === 0) {
            return html`
                <tr>
                    <td colspan="10" class="text-center py-4">
                        등록된 배너가 없습니다.
                    </td>
                </tr>
            `;
        }

        return this.items.map((item, index) => html`
            <tr>
                <td class="text-center">${this.totalCount - ((this.page - 1) * this.pagesize) - index}</td>
                <td class="text-center">${item.bannername}</td>
                <td class="text-center">${item.bannerprice <= 0 ? "무료" : "유료"}</td>
                <td class="text-center">${formatDate(item.regdate) ?? ""}</td>
                <td class="text-center">${formatDate(item.sdate) ?? ""} ~ ${formatDate(item.edate) ?? ""}</td>
                <td class="text-center">${item.companyname ?? ""}</td>
                <td class="text-center">
                    ${item.bannerimage ? html`
                        <img src=/Data/BannerImg/${item.bannerimage}
                             width="60"
                             alt="배너 이미지">
                    ` : ""}
                </td>
                <td>${item.bannersubject ?? ""}</td>
                <td class="text-center">${this.renderBannerStatus(item.remaindays, item.sdate, item.bannerwaiting, item.isuse)}</td>
                <td class="text-end">${item.bannerprice ?? ""}</td>
            </tr>
        `);
    }

    renderPaging() {

        if (this.bannerIdx === null ||
            this.loading ||
            this.error ||
            this.totalCount === 0) {
            return html``;
        }

        const totalPages = Math.ceil(
            this.totalCount / this.pagesize
        );

        const blockSize = 5;

        const startPage =
            Math.floor((this.page - 1) / blockSize)
            * blockSize + 1;

        const endPage = Math.min(
            startPage + blockSize - 1,
            totalPages
        );

        const pages = Array.from(
            { length: endPage - startPage + 1 },
            (_, i) => startPage + i
        );

        return html`
        <div class="d-flex align-items-center justify-content-between p-3">

            <div class="text-secondary">
                전체 ${this.totalCount}건
            </div>

            <ul class="pagination mb-0">

                <li class="page-item
                    ${this.page === 1 ? "disabled" : ""}">
                    <button class="page-link"
                            ?disabled=${this.page === 1}
                            @click=${() =>
                this.changePage(this.page - 1)}>
                        이전
                    </button>
                </li>

                ${pages.map(p => html`
                    <li class="page-item
                        ${this.page === p ? "active" : ""}">

                        <button class="page-link"
                                @click=${() =>
                        this.changePage(p)}>
                            ${p}
                        </button>
                    </li>
                `)}

                <li class="page-item
                    ${this.page === totalPages ? "disabled" : ""}">
                    <button class="page-link"
                            ?disabled=${this.page === totalPages}
                            @click=${() =>
                this.changePage(this.page + 1)}>
                        다음
                    </button>
                </li>

            </ul>
        </div>
    `;
    }

    render() {
        return html`
            <table class="table table-vcenter mb-0">
                <thead>
                    <tr class="text-center">
                        <th style="width:5%;">No.</th>
                        <th style="width:20%;">배너위치</th>
                        <th style="width:8%;">유/무료</th>
                        <th style="width:10%;">등록일</th>
                        <th style="width:10%;">게재기간</th>
                        <th style="width:10%;">업체명</th>
                        <th style="width:10%;">이미지</th>
                        <th class="text-center">메모</th>
                        <th style="width:10%;">상태</th>
                        <th style="width:10%;">금액</th>
                    </tr>
                </thead>

                <tbody>
                    ${this.renderRows()}
                </tbody>
            </table>

            ${this.renderPaging()}
        `;
    }

    changePage(page) {

        this.page = page

        const totalPages = Math.ceil(
            this.totalCount / this.pagesize
        );

        if (this.loading || page < 1 || page > totalPages) {
            return;
        }


        

        // 현재 배너 위치를 유지하면서 페이지 변경
        this.getBannerList();
    }

    renderBannerStatus(remaindays, sdate, bannerwaiting, isuse) {

        const today = new Date();
        today.setHours(0, 0, 0, 0);

        if (remaindays <= 0) {
            return html`<span class="badge bg-secondary-lt">마감</span>`;
        }

        if (isuse != "Y") {
            return html`<span class="badge bg-dark-lt">중단</span>`;
        }

        if (bannerwaiting == "Y") {
            return html`<span class="badge bg-warning-lt">대기</span>`;
        }

        if (new Date(sdate) > today) {
            return html`<span class="badge bg-primary-lt">예약</span>`;
        }


        if (remaindays <= 30) {
            return html`<span class="badge bg-red-lt">마감임박</span>`;
        }

        return html`<span class="badge bg-green-lt">운영중</span> `;
    }
}

customElements.define("banner-search-data-list", BannerSearchList);