using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Freemold.Modules.Repositories
{
    public class ProductRepository : BaseRepository
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductRepository(AppDbContext _appdbcontext, IDbContextFactory<AppDbContext> factory, IHttpContextAccessor httpContextAccessor) : base(_appdbcontext)
        {
            _factory = factory;
            _httpContextAccessor = httpContextAccessor;
        }

        //allinkbeauty 문의사항 상세내용
        public IQueryable<AdminProductDetailModel> GetInquiryProductView()
        {
            try
            {
                var query = from i in _appdbcontext.ProductLists
                            join p in _appdbcontext.Member1
                                on i.MEMBER_UID equals p.UID
                            select new AdminProductDetailModel
                            {
                                ProdUid = i.PROD_UID,
                                pimg1 = i.P_IMG1,
                                pname = i.P_NAME,
                                pcode = i.P_CODE,
                                pcodeen = i.P_CODE_EN,
                                pcapacity = i.P_CAPACITY,
                                pcapunit = i.P_CAP_UNIT,
                                psize = i.P_SIZE,
                                pquality = i.P_QUALITY,
                                memberuid = i.MEMBER_UID,
                                company_name = p.COMPANY_NAME
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<KbeautyProductModel> GetKbeautyProductList(string Acode = "A001")
        {
            try
            {
                var prodUids = (from i in _appdbcontext.ProductLists
                                let catNorm = i.Cat.Replace(";"+ Acode+";", "").Replace(";;", ",").Replace(";", "")
                                from s in _appdbcontext.FnSplit(catNorm, ",")
                                join c in _appdbcontext.VwNcategoryLists on s.Val equals c.Code
                                where c.StdMld == "Y" && EF.Functions.Like(i.UpCat, "%" + Acode + "%")
                                select i.PROD_UID).Distinct();


                var query = from i in _appdbcontext.ProductLists
                            join p in _appdbcontext.Member1 on i.MEMBER_UID equals p.UID
                            where prodUids.Contains(i.PROD_UID) && (p.CO_REMOVE ?? "N") != "Y" //탈퇴회원 제외
                            && i.Deleted == "N"
                            && i.P_APPROVAL == "Y"                  //제폼승인1
                            && (i.P_APPROVAL_BEFORE ?? "") == "Y"   //제폼승인2
                            && i.P_USE == "1"                       //제품노출
                            && i.P_USE_ST == "Y"                    //ST노출여부
                            && p.APPROVAL == "Y"                    //기업승인1
                            && (p.APPROVAL_BEFORE ?? "") == "Y"     //기업승인2
                            && p.APPROVAL_VIEW == "Y"
                            select new KbeautyProductModel
                            {
                                ProdUid = i.PROD_UID,
                                PCode = i.P_CODE,
                                PCodeEn = i.P_CODE_EN,
                                UpCat = i.UpCat,
                                PName = i.P_NAME,
                                PCapacity = i.P_CAPACITY,
                                PCapUnit = i.P_CAP_UNIT,
                                PSize = i.P_SIZE,
                                PHit = i.P_HIT,
                                PQuality = i.P_QUALITY,
                                POrigin = i.P_ORIGIN,
                                ProdType = i.ProdType,
                                PCategory = i.P_CATEGORY,
                                PImg1 = i.P_IMG1,
                                PApproval = i.P_APPROVAL,
                                PApprovalBefore = i.P_APPROVAL_BEFORE,
                                Deleted = i.Deleted,
                                PUse = i.P_USE,
                                PUseST = i.P_USE_ST,
                                PRegDate = i.P_REGDATE,
                                Visit = i.Visit,
                                CompanyName = p.COMPANY_NAME,
                                PayUse = p.PayUse,
                                Approval = p.APPROVAL,
                                ApprovalBefore = p.APPROVAL_BEFORE,
                                ApprovalView = p.APPROVAL_VIEW,
                                StartDate = p.START_DATE,
                                EndDate = p.END_DATE,
                                ImgCnt = AppDbContext.FnImageCount(i.PROD_UID)
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<UspKbeautyProductModel> GetuspKbeautyProductList(string Acode = "A001")
        {
            try
            {
                var query = _appdbcontext.UspKbeautyProductList
                    .FromSqlRaw("EXEC Usp_Kbeauty_Product_List {0}", Acode)
                    .AsNoTracking();



                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<KbeautyProductModel> GetKbeautyProductView()
        {
            try
            {

                var query = from i in _appdbcontext.ProductLists
                            join p in _appdbcontext.Member1 on i.MEMBER_UID equals p.UID
                            where i.Deleted == "N" &&
                                    i.P_APPROVAL == "Y" &&
                                    (i.P_APPROVAL_BEFORE ?? "") == "Y" &&
                                    (p.CO_REMOVE ?? "N") != "Y" //탈퇴회원 제외
                            select new KbeautyProductModel
                            {
                                ProdUid = i.PROD_UID,
                                PCode = i.P_CODE,
                                PCodeEn = i.P_CODE_EN,
                                PCapacity = i.P_CAPACITY,
                                PCapUnit = i.P_CAP_UNIT,
                                PSize = i.P_SIZE,
                                PQuality = i.P_QUALITY,
                                PImg1 = i.P_IMG1,
                                PImg2 = i.P_IMG2,
                                PImg3 = i.P_IMG3,
                                PImg4 = i.P_IMG4,
                                PImg5 = i.P_IMG5,
                                PImg6 = i.P_IMG6,
                                PMemoEng = i.P_MEMO_ENG
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<AdminProductModel> GetProductList()
        {
            try
            {
                var query = from i in _appdbcontext.ProductLists
                            let catNorm = i.Cat.Replace(";;", ",").Replace(";", "")
                            from s in _appdbcontext.FnSplit(catNorm, ",")
                            join c in _appdbcontext.VwNcategoryLists on s.Val equals c.Code
                            join p in _appdbcontext.Member1 on i.MEMBER_UID equals p.UID
                            select new AdminProductModel
                            {
                                ProdUid = i.PROD_UID,
                                PUseSt = i.P_USE_ST,
                                PHot = i.P_HOT,
                                PNew = i.P_NEW,
                                PName = i.P_NAME,
                                PCategory = i.P_CATEGORY,
                                PCode = i.P_CODE,
                                PCodeEn = i.P_CODE_EN,
                                PCapacity = i.P_CAPACITY,
                                PCapUnit = i.P_CAP_UNIT,
                                PApproval = i.P_APPROVAL,
                                PSeq = i.P_SEQ,
                                PRegdate = i.P_REGDATE,
                                PModdate = i.P_MODDATE,
                                PAppdate = i.P_APPDATE,
                                PSize = i.P_SIZE,
                                PHit = i.P_HIT,
                                PQuality = i.P_QUALITY,
                                POrigin = i.P_ORIGIN,
                                ProdType = i.ProdType,
                                Visit = i.Visit,
                                PImg1 = i.P_IMG1,
                                PImg2 = i.P_IMG2,
                                PImg3 = i.P_IMG3,
                                PImg4 = i.P_IMG4,
                                PImg5 = i.P_IMG5,
                                PImg6 = i.P_IMG6,
                                Deleted = i.Deleted,
                                MemberUid = i.MEMBER_UID,
                                CompanyName = p.COMPANY_NAME,
                                PayUse = p.PayUse,
                                Approval = p.APPROVAL,
                                ImgCnt = AppDbContext.FnImageCount(i.PROD_UID)

                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<AdminProductModel> GetKProductList()
        {
            try
            {
                var query = from i in _appdbcontext.VwProductListSms
                            join p in _appdbcontext.Member1
                                on i.MemberUid equals p.UID
                            join c in _appdbcontext.TbStandardProdMains
                                on i.ProdUid equals c.PIdx into sd
                            from c in sd.DefaultIfEmpty()
                            select new AdminProductModel
                            {
                                ProdUid = i.ProdUid,
                                PUseSt = i.PUseSt,
                                PHot = i.PHot,
                                PNew = i.PNew,
                                PName = i.PName,
                                PCategory = i.PCategory,
                                PCode = i.PCode,
                                PCodeEn = i.PCodeEn,
                                PCapacity = i.PCapacity,
                                PCapUnit = i.PCapUnit,
                                PApproval = i.PApproval,
                                PSeq = i.PSeq,
                                PRegdate = i.PRegdate,
                                PModdate = i.PModdate,
                                PAppdate = i.PAppdate,
                                PSize = i.PSize,
                                PHit = i.PHit,
                                PQuality = i.PQuality,
                                POrigin = i.POrigin,
                                ProdType = i.ProdType,
                                Visit = i.Visit,
                                PImg1 = i.PImg1,
                                PImg2 = i.PImg2,
                                PImg3 = i.PImg3,
                                PImg4 = i.PImg4,
                                PImg5 = i.PImg5,
                                PImg6 = i.PImg6,
                                Deleted = i.Deleted,
                                MemberUid = i.MemberUid,
                                CompanyName = p.COMPANY_NAME,
                                PayUse = p.PayUse,
                                Approval = p.APPROVAL,
                                Sort = c.Sort,
                                IsUse = c.IsUse,
                                ImgCnt = AppDbContext.FnImageCount(i.ProdUid)

                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<AdminProductModel> GetCProductList()
        {
            try
            {
                var query = from i in _appdbcontext.ProductLists
                            join p in _appdbcontext.Member1
                                on i.MEMBER_UID equals p.UID
                            join c in _appdbcontext.TbStandardProdMains
                                on i.PROD_UID equals c.PIdx into sd
                            from c in sd.DefaultIfEmpty()
                            select new AdminProductModel
                            {
                                ProdUid = i.PROD_UID,
                                PUseSt = i.P_USE_ST,
                                PHot = i.P_HOT,
                                PNew = i.P_NEW,
                                PName = i.P_NAME,
                                PCategory = i.P_CATEGORY,
                                PCode = i.P_CODE,
                                PCodeEn = i.P_CODE_EN,
                                PCapacity = i.P_CAPACITY,
                                PCapUnit = i.P_CAP_UNIT,
                                PApproval = i.P_APPROVAL,
                                PSeq = i.P_SEQ,
                                PRegdate = i.P_REGDATE,
                                PModdate = i.P_MODDATE,
                                PAppdate = i.P_APPDATE,
                                PSize = i.P_SIZE,
                                PHit = i.P_HIT,
                                PQuality = i.P_QUALITY,
                                POrigin = i.P_ORIGIN,
                                ProdType = i.ProdType,
                                Visit = i.Visit,
                                PImg1 = i.P_IMG1,
                                PImg2 = i.P_IMG2,
                                PImg3 = i.P_IMG3,
                                PImg4 = i.P_IMG4,
                                PImg5 = i.P_IMG5,
                                PImg6 = i.P_IMG6,
                                Deleted = i.Deleted,
                                MemberUid = i.MEMBER_UID,
                                CompanyName = p.COMPANY_NAME,
                                PayUse = p.PayUse,
                                Approval = p.APPROVAL,
                                Sort = c.Sort,
                                IsUse = c.IsUse,
                                ImgCnt = AppDbContext.FnImageCount(i.PROD_UID)

                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<ProductDetailModel> GetProductView()
        {
            try
            {
                var query = from i in _appdbcontext.ProductLists
                            join p in _appdbcontext.Member1
                                on i.MEMBER_UID equals p.UID
                            select new ProductDetailModel
                            {
                                ProdUid = i.PROD_UID,
                                ItId = i.it_id,
                                CoId = i.CO_ID,
                                MemberGubun = i.MEMBER_GUBUN,
                                MemberUid = i.MEMBER_UID,
                                PCategory = i.P_CATEGORY,
                                PName = i.P_NAME,
                                PName2 = i.P_NAME2,
                                PCode = i.P_CODE,
                                PCodeEn = i.P_CODE_EN,
                                PMoq = i.P_MOQ,
                                PMoqDeal = i.P_MOQ_DEAL,
                                PImg1 = i.P_IMG1,
                                PImg2 = i.P_IMG2,
                                PImg3 = i.P_IMG3,
                                PImg4 = i.P_IMG4,
                                PImg5 = i.P_IMG5,
                                PImg6 = i.P_IMG6,
                                PCapacity = i.P_CAPACITY,
                                PCapUnit = i.P_CAP_UNIT,
                                PSize = i.P_SIZE,
                                POrigin = i.P_ORIGIN,
                                PMemo = i.P_MEMO,
                                PMemo2 = i.P_MEMO2,
                                PMemoEng = i.P_MEMO_ENG,
                                PRegdate = i.P_REGDATE,
                                PModdate = i.P_MODDATE,
                                PAppdate = i.P_APPDATE,
                                PUse = i.P_USE,
                                PUseSt = i.P_USE_ST,
                                PNew = i.P_NEW,
                                PHot = i.P_HOT,
                                PQuality = i.P_QUALITY,
                                PSeq = i.P_SEQ,
                                PHit = i.P_HIT,
                                IsRefill = i.isRefill,
                                IsPcr = i.isPCR,
                                IsMove = i.isMove,
                                Visit = i.Visit,
                                PApproval = i.P_APPROVAL,
                                ProdType = i.ProdType,
                                Deleted = i.Deleted,
                                UpCat = i.UpCat,
                                Cat = i.Cat,
                                Tag0 = i.Tag0,
                                Tag1 = i.Tag1,
                                Tag2 = i.Tag2,
                                Tag3 = i.Tag3,
                                Tag4 = i.Tag4,
                                Tag5 = i.Tag5,
                                Tag6 = i.Tag6,
                                Tag7 = i.Tag7,
                                Tag8 = i.Tag8,
                                Tag9 = i.Tag9,
                                Uid = p.UID,
                                CompanyName = p.COMPANY_NAME,
                                CompanyNameE = p.COMPANY_NAME_E,
                                CompanyNameC = p.COMPANY_NAME_C,
                                Tel = p.TEL,
                                Fax = p.FAX,
                                Mobile = p.MOBILE,
                                Email = p.EMAIL,
                                Mainemail = p.MAINEMAIL,
                                Damdang = p.DAMDANG,
                                DamdangTel = p.DAMDANG_TEL,
                                DamdangDep = p.DAMDANG_DEP,
                                DamdangPos = p.DAMDANG_POS,
                                DamdangEmail = p.DAMDANG_EMAIL,
                                ComType = p.ComType
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> ProductUpdate(ProductSaveModel productSaveModel)
        {

            string result = "sucess";

            try
            {
                var p = await _appdbcontext.ProductLists.FirstAsync(x => x.PROD_UID == productSaveModel.produid);

                var bak = new BakProductList
                {
                    PROD_UID = p.PROD_UID,
                    it_id = p.it_id,
                    CO_ID = p.CO_ID,
                    MEMBER_GUBUN = p.MEMBER_GUBUN,
                    MEMBER_UID = p.MEMBER_UID,
                    P_CATEGORY = p.P_CATEGORY,
                    P_NAME = p.P_NAME,
                    P_NAME2 = p.P_NAME2,
                    P_CODE = p.P_CODE,
                    P_CODE_EN = p.P_CODE_EN,
                    P_MOQ = p.P_MOQ,
                    P_MOQ_DEAL = p.P_MOQ_DEAL,
                    P_IMG1 = p.P_IMG1,
                    P_IMG2 = p.P_IMG2,
                    P_IMG3 = p.P_IMG3,
                    P_IMG4 = p.P_IMG4,
                    P_IMG5 = p.P_IMG5,
                    P_IMG6 = p.P_IMG6,
                    P_CAPACITY = p.P_CAPACITY.ToString(),
                    P_CAP_UNIT = p.P_CAP_UNIT,
                    P_SIZE = p.P_SIZE,
                    P_ORIGIN = p.P_ORIGIN,
                    P_MEMO = p.P_MEMO,
                    P_MEMO2 = p.P_MEMO2,
                    P_MEMO_ENG = p.P_MEMO_ENG,
                    P_REGDATE = p.P_REGDATE,
                    P_MODDATE = p.P_MODDATE,
                    P_APPDATE = p.P_APPDATE,
                    P_APPDATE_BEFORE = p.P_APPDATE_BEFORE,
                    P_USE = p.P_USE,
                    P_USE_ST = p.P_USE_ST,
                    P_NEW = p.P_NEW,
                    P_HOT = p.P_HOT,
                    P_QUALITY = p.P_QUALITY,
                    P_SEQ = p.P_SEQ,
                    P_HIT = p.P_HIT,
                    isRefill = p.isRefill,
                    isPCR = p.isPCR,
                    isMove = p.isMove,
                    Visit = p.Visit,
                    P_APPROVAL_BEFORE = p.P_APPROVAL_BEFORE,
                    P_APPROVAL = p.P_APPROVAL,
                    P_APPRUSER_BEFORE = p.P_APPRUSER_BEFORE,
                    P_APPRUSER = p.P_APPRUSER,
                    ProdType = p.ProdType,
                    Deleted = p.Deleted,
                    UpCat = p.UpCat,
                    Cat = p.Cat,
                    Tag0 = p.Tag0,
                    Tag1 = p.Tag1,
                    Tag2 = p.Tag2,
                    Tag3 = p.Tag3,
                    Tag4 = p.Tag4,
                    Tag5 = p.Tag5,
                    Tag6 = p.Tag6,
                    Tag7 = p.Tag7,
                    Tag8 = p.Tag8,
                    Tag9 = p.Tag9,
                    BRegType = "제품수정",
                    BRegID = "allinkbeuaty",//임의로 아이디 등록
                    BRegIP = "",
                    BRegDate = DateTime.Now

                };

                //bak 저장
                _appdbcontext.BakProductLists.Add(bak);

                //수정
                p.P_CATEGORY = productSaveModel.p_category;
                p.P_CODE = productSaveModel.p_code;
                p.P_CODE_EN = productSaveModel.p_code_en;
                p.P_NAME = productSaveModel.p_name;
                p.P_CAPACITY = productSaveModel.p_capacity;
                p.P_SIZE = productSaveModel.p_size;
                p.P_QUALITY = productSaveModel.p_quality;
                p.P_ORIGIN = productSaveModel.p_origin;
                p.P_MEMO = productSaveModel.p_memo;
                p.P_MEMO_ENG = productSaveModel.p_memo_en;
                p.P_IMG1 = productSaveModel.p_img1;
                p.P_IMG2 = productSaveModel.p_img2;
                p.P_IMG3 = productSaveModel.p_img3;
                p.P_IMG4 = productSaveModel.p_img4;
                p.P_IMG5 = productSaveModel.p_img5;
                p.P_IMG6 = productSaveModel.p_img6;
                p.P_MODDATE = DateTime.Now;

                var rows = await _appdbcontext.SaveChangesAsync();

                if (rows <= 0) result = "fail";
            }
            catch (Exception ex)
            {
                result = "fail";

                _appdbcontext.ChangeTracker.Clear();      // 선택: 메모리 상태 초기화
                throw;
            }


            return result;
        }


        public async Task<string> ProductViewUpdate(long ProdUid, string PUseSt)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var admin = httpContext?.Session?.GetString("admin") ?? "allinkbeauty";
            string result = "OK";

            try
            {
                var p = await _appdbcontext.ProductLists.FirstAsync(x => x.PROD_UID == ProdUid);

                var bak = new BakProductList
                {
                    PROD_UID = p.PROD_UID,
                    it_id = p.it_id,
                    CO_ID = p.CO_ID,
                    MEMBER_GUBUN = p.MEMBER_GUBUN,
                    MEMBER_UID = p.MEMBER_UID,
                    P_CATEGORY = p.P_CATEGORY,
                    P_NAME = p.P_NAME,
                    P_NAME2 = p.P_NAME2,
                    P_CODE = p.P_CODE,
                    P_CODE_EN = p.P_CODE_EN,
                    P_MOQ = p.P_MOQ,
                    P_MOQ_DEAL = p.P_MOQ_DEAL,
                    P_IMG1 = p.P_IMG1,
                    P_IMG2 = p.P_IMG2,
                    P_IMG3 = p.P_IMG3,
                    P_IMG4 = p.P_IMG4,
                    P_IMG5 = p.P_IMG5,
                    P_IMG6 = p.P_IMG6,
                    P_CAPACITY = p.P_CAPACITY.ToString(),
                    P_CAP_UNIT = p.P_CAP_UNIT,
                    P_SIZE = p.P_SIZE,
                    P_ORIGIN = p.P_ORIGIN,
                    P_MEMO = p.P_MEMO,
                    P_MEMO2 = p.P_MEMO2,
                    P_REGDATE = p.P_REGDATE,
                    P_MODDATE = p.P_MODDATE,
                    P_APPDATE = p.P_APPDATE,
                    P_APPDATE_BEFORE = p.P_APPDATE_BEFORE,
                    P_USE = p.P_USE,
                    P_USE_ST = p.P_USE_ST,
                    P_NEW = p.P_NEW,
                    P_HOT = p.P_HOT,
                    P_QUALITY = p.P_QUALITY,
                    P_SEQ = p.P_SEQ,
                    P_HIT = p.P_HIT,
                    isRefill = p.isRefill,
                    isPCR = p.isPCR,
                    isMove = p.isMove,
                    Visit = p.Visit,
                    P_APPROVAL_BEFORE = p.P_APPROVAL_BEFORE,
                    P_APPROVAL = p.P_APPROVAL,
                    P_APPRUSER_BEFORE = p.P_APPRUSER_BEFORE,
                    P_APPRUSER = p.P_APPRUSER,
                    ProdType = p.ProdType,
                    Deleted = p.Deleted,
                    UpCat = p.UpCat,
                    Cat = p.Cat,
                    Tag0 = p.Tag0,
                    Tag1 = p.Tag1,
                    Tag2 = p.Tag2,
                    Tag3 = p.Tag3,
                    Tag4 = p.Tag4,
                    Tag5 = p.Tag5,
                    Tag6 = p.Tag6,
                    Tag7 = p.Tag7,
                    Tag8 = p.Tag8,
                    Tag9 = p.Tag9,
                    BRegType = "제품수정",
                    BRegID = admin,
                    BRegIP = "",
                    BRegDate = DateTime.Now

                };

                //bak 저장
                _appdbcontext.BakProductLists.Add(bak);


                p.P_USE_ST = PUseSt;

                var rows = await _appdbcontext.SaveChangesAsync();

                if (rows <= 0) result = "FAIL";


                //await _appdbcontext.SaveChangesAsync();
            }
            catch
            {
                result = "FAIL";

                // DB는 롤백됨. 하지만 트래커엔 변경 흔적이 남아있을 수 있어요.
                _appdbcontext.ChangeTracker.Clear();      // 선택: 메모리 상태 초기화
                throw;
            }


            return result;
        }

        
    }
}
