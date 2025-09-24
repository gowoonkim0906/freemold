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
                            join p in _appdbcontext.Member1s
                                on i.MemberUid equals p.Uid
                            select new AdminProductDetailModel
                            {
                                ProdUid = i.ProdUid,
                                pimg1 = i.PImg1,
                                pname = i.PName,
                                pcode = i.PCode,
                                pcapacity = i.PCapacity,
                                pcapunit = i.PCapUnit,
                                psize = i.PSize,
                                pquality = i.PQuality,
                                memberuid = i.MemberUid,
                                company_name = p.CompanyName
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
                            join p in _appdbcontext.Member1s
                                on i.MemberUid equals p.Uid
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
                                CompanyName = p.CompanyName,
                                PayUse = p.PayUse,
                                Approval = p.Approval,
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
                            join p in _appdbcontext.Member1s
                                on i.MemberUid equals p.Uid
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
                                CompanyName = p.CompanyName,
                                PayUse = p.PayUse,
                                Approval = p.Approval,
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

        public IQueryable<ProductDetailModel> GetProductView()
        {
            try
            {
                var query = from i in _appdbcontext.ProductLists
                            join p in _appdbcontext.Member1s
                                on i.MemberUid equals p.Uid
                            select new ProductDetailModel
                            {
                                ProdUid = i.ProdUid,
                                ItId = i.ItId,
                                CoId = i.CoId,
                                MemberGubun = i.MemberGubun,
                                MemberUid = i.MemberUid,
                                PCategory = i.PCategory,
                                PName = i.PName,
                                PName2 = i.PName2,
                                PCode = i.PCode,
                                PMoq = i.PMoq,
                                PMoqDeal = i.PMoqDeal,
                                PImg1 = i.PImg1,
                                PImg2 = i.PImg2,
                                PImg3 = i.PImg3,
                                PImg4 = i.PImg4,
                                PImg5 = i.PImg5,
                                PImg6 = i.PImg6,
                                PCapacity = i.PCapacity,
                                PCapUnit = i.PCapUnit,
                                PSize = i.PSize,
                                POrigin = i.POrigin,
                                PMemo = i.PMemo,
                                PMemo2 = i.PMemo2,
                                PRegdate = i.PRegdate,
                                PModdate = i.PModdate,
                                PAppdate = i.PAppdate,
                                PUse = i.PUse,
                                PUseSt = i.PUseSt,
                                PNew = i.PNew,
                                PHot = i.PHot,
                                PQuality = i.PQuality,
                                PSeq = i.PSeq,
                                PHit = i.PHit,
                                IsRefill = i.IsRefill,
                                IsPcr = i.IsPcr,
                                IsMove = i.IsMove,
                                Visit = i.Visit,
                                PApproval = i.PApproval,
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

                                Uid = p.Uid,
                                CompanyName = p.CompanyName,
                                CompanyNameE = p.CompanyNameE,
                                CompanyNameC = p.CompanyNameC,
                                Tel = p.Tel,
                                Fax = p.Fax,
                                Mobile = p.Mobile,
                                Email = p.Email,
                                Mainemail = p.Mainemail,
                                Damdang = p.Damdang,
                                DamdangTel = p.DamdangTel,
                                DamdangDep = p.DamdangDep,
                                DamdangPos = p.DamdangPos,
                                DamdangEmail = p.DamdangEmail,
                                ComType = p.ComType
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }


        public async Task<string> ProductViewUpdate(long ProdUid , string PUseSt)
        {

            string result = "OK";

            try
            {
                var p = await _appdbcontext.ProductLists.FirstAsync(x => x.ProdUid == ProdUid);
                p.PUseSt = PUseSt;

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
