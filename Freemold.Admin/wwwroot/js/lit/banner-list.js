
import { LitElement, html } from "../vendor/lit.js";

class BannerDataList extends LitElement {

    static properties = {
        bannerIdx: { state: true },
        items: { state: true },
        loading: { state: true },
        error: { state: true },
        page: { state: true },
        pagesize: { state: true },
        totalCount: { state: true }
    };

    constructor() {
        super();
        this.bannerIdx = null;
        this.items = [];
        this.loading = false;
        this.error = "";
        this.requestController = null;
        this.page = 1;          // 현재 페이지
        this.pagesize = 10;     // 한 페이지당 10개
        this.totalCount = 0;    // 전체 데이터 건수
    }

    // 기존 Bootstrap / Tabler CSS 사용
    createRenderRoot() {
        return this;
    }

    // 왼쪽 메뉴에서 호출할 함수
    async selectBanner(bannerIdx, page, pagesize, searchtype) {

        this.bannerIdx = bannerIdx;
        this.page = page;
        this.items = [];
        this.error = "";
        this.loading = true;
        this.page = page;          
        this.pagesize = pagesize;     

        // 이전 요청이 진행 중이면 취소
        this.requestController?.abort();

        const controller = new AbortController();
        this.requestController = controller;

        try {
            const params = new URLSearchParams({
                bidx: bannerIdx,
                page: page,
                pagesize: pagesize,
                searchtype: searchtype

            });

            // 실제 ASP.NET Core API 경로로 변경
            //const response = await fetch(
            //    `/api/banner/list?${params}`,
            //    { signal: controller.signal }
            //);

            const response = await fetch(
                "/Banner/AjaxGetTypeBanner",
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
                throw new Error("HTTP 오류: " + response.status);
            }

            const data = await response.json();

            if (data.item1 === "fail") {
                throw new Error("서버에서 배너 조회 실패");
            }

            // 현재 요청에 대한 결과만 반영
            if (this.requestController === controller) {

                this.items = Array.isArray(data.items)
                    ? data.items
                    : [];

                // 전체 데이터 건수 - 중요!
                this.totalCount = Number(data.totalCount) || 0;
            }


        } catch (error) {
            if (error.name !== "AbortError" &&
                this.requestController === controller) {

                console.error(error);
                this.error = "배너 목록 조회에 실패했습니다.";
            }

        } finally {
            if (this.requestController === controller) {
                this.loading = false;
                this.requestController = null;
            }
        }
    }

    disconnectedCallback() {
        this.requestController?.abort();
        super.disconnectedCallback();
    }

    renderRows() {

        if (this.bannerIdx === null) {
            return html`
                <tr>
                    <td colspan="11"
                        class="text-center text-secondary py-4">
                        좌측 배너위치를 선택해주세요.
                    </td>
                </tr>
            `;
        }

        if (this.loading) {
            return html`
                <tr>
                    <td colspan="11"
                        class="text-center py-4">
                        데이터를 조회하고 있습니다.
                    </td>
                </tr>
            `;
        }

        if (this.error) {
            return html`
                <tr>
                    <td colspan="11"
                        class="text-center text-danger py-4">
                        ${this.error}
                    </td>
                </tr>
            `;
        }

        if (this.items.length === 0) {
            return html`
                <tr>
                    <td colspan="11"
                        class="text-center py-4">
                        등록된 배너가 없습니다.
                    </td>
                </tr>
            `;
        }

        return this.items.map((item, index) => html`
            <tr>
                <td class="text-center">
                    <input type="checkbox" class="form-check-input" name="uniqueidx" value=${String(item.idx ?? "")}>
                </td>
                <td class="text-center">${this.totalCount - ((this.page - 1) * this.pagesize) - index}</td>
                <td class="text-center">${this.renderBannerStatus(item.remaindays, item.sdate, item.bannerwaiting, item.isuse)}</td>
                <td class="text-center">${formatDate(item.regdate) ?? ""}</td>
                <td class="text-center">${formatDate(item.sdate) ?? ""} ~ ${formatDate(item.edate) ?? ""}</td>
                <td class="text-center">${item.company_name ?? ""}</td>
                <td class="text-center">
                    ${item.imageUrl ? html`
                        <img src=/Data/BannerImg/${item.imageUrl}
                             width="60"
                             alt="배너 이미지">
                    ` : ""}
                </td>
                <td class="text-center">${item.isuse ?? ""}</td>
                <td>${item.bannersubject ?? ""}</td>
                <td class="text-end">${item.bannerprice ?? ""}</td>
                <td class="text-center">
                    <button type="button" class="btn btn-sm btn-primary" @click=${() => window.bannersetmodal(item.idx)}>
                        수정
                    </button>
                    <button type="button" class="btn btn-sm btn-danger" @click=${() => this.deleteBanner(item.idx)}>
                        삭제
                    </button>
                </td>
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
                    <tr>
                        <th width="5%" class="text-center">
                            <input type="checkbox"
                                   class="form-check-input">
                        </th>
                        <th width="5%" class="text-center">번호</th>
                        <th width="5%" class="text-center">상태</th>
                        <th width="8%" class="text-center">등록일</th>
                        <th width="10%" class="text-center">게재기간</th>
                        <th width="10%" class="text-center">업체명</th>
                        <th class="text-center">이미지</th>
                        <th width="5%" class="text-center">노출</th>
                        <th width="20%" class="text-center">메모</th>
                        <th width="8%" class="text-center">금액</th>
                        <th width="10%" class="text-center">관리</th>
                    </tr>
                </thead>

                <tbody>
                    ${this.renderRows()}
                </tbody>
            </table>

            ${this.renderPaging()}
        `;
    }


    async editBanner(idx) {

        // 추후 수정 모달 호출
        // this.openEditModal(idx);
    }

    async deleteBanner(idx) {

        if (!confirm("선택한 배너를 삭제하시겠습니까?")) {
            return;
        }

        try {
            const response = await fetch(
                "/Banner/AjaxDeleteTypeBanner",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded"
                    },
                    body: new URLSearchParams({
                        idx: idx,
                        deleteyn: "Y",
                        memberId: "freemold",
                        regIp : "127.0.0.1"

                    })
                }
            );

            if (!response.ok) {
                throw new Error("서버 요청 실패");
            }

            const data = await response.json();


            console.log(data);

            // 삭제 성공 시 새로고침
            if (data.items === "success") {
                alert("삭제되었습니다.");


                const totalCount = Math.max(0, this.totalCount - 1);

                const lastPage = Math.max(
                    1,
                    Math.ceil(totalCount / this.pagesize)
                );

                await this.selectBanner(
                    this.bannerIdx,
                    Math.min(this.page, lastPage),
                    this.pagesize
                );

            } else {
                alert("삭제에 실패했습니다.");
            }

        } catch (error) {
            console.error("배너 삭제 오류:", error);
            alert("삭제 처리 중 오류가 발생했습니다.");
        }

        console.log("삭제할 배너:", idx);

        // 실제 삭제 Controller 연결 시 구현
    }

    changePage(page) {

        const totalPages = Math.ceil(
            this.totalCount / this.pagesize
        );

        if (this.loading || page < 1 || page > totalPages) {
            return;
        }

        // 현재 배너 위치를 유지하면서 페이지 변경
        this.selectBanner(
            this.bannerIdx,
            page,
            this.pagesize
        );
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

customElements.define("banner-data-list", BannerDataList);



