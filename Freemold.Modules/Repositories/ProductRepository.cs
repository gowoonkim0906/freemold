using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Freemold.Modules.Repositories
{
    public class ProductRepository : BaseRepository
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public ProductRepository(AppDbContext _appdbcontext, IDbContextFactory<AppDbContext> factory) : base(_appdbcontext)
        {
            _factory = factory;
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
                                PCapacity = i.PCapacity,
                                PCapUnit = i.PCapUnit,
                                PApproval = i.PApproval,
                                PSeq = i.PSeq,
                                PRegdate = i.PRegdate,
                                PModdate = i.PModdate,
                                PAppdate = i.PAppdate,
                                PSize   = i.PSize,
                                PHit    = i.PHit,
                                PQuality    = i.PQuality,
                                POrigin = i.POrigin,
                                ProdType  = i.ProdType,
                                Visit  = i.Visit,
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

        public async Task<string> ProductUpdate(ProductSaveModel productSaveModel) {

            string result = "OK";

            try
            {
                var p = await _appdbcontext.ProductLists.FirstAsync(x => x.PROD_UID == productSaveModel.produid);
                p.P_CODE = productSaveModel.p_code;
                p.P_NAME = productSaveModel.p_name;
                p.P_CAPACITY = productSaveModel.p_capacity; 
                p.P_SIZE = productSaveModel.p_size;
                p.P_QUALITY = productSaveModel.p_quality;
                p.P_ORIGIN = productSaveModel.p_origin;

                await _appdbcontext.SaveChangesAsync();
            }
            catch
            {
                result = "FAIL";

                _appdbcontext.ChangeTracker.Clear();      // 선택: 메모리 상태 초기화
                throw;
            }


            return result;
        }


        public async Task<string> ProductViewUpdate(long ProdUid , string PUseSt)
        {

            string result = "OK";

            try
            {
                var p = await _appdbcontext.ProductLists.FirstAsync(x => x.PROD_UID == ProdUid);
                p.P_USE_ST = PUseSt;

                await _appdbcontext.SaveChangesAsync();
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
