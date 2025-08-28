using Freemold.Modules.Common;
using Freemold.Modules.Models;

namespace Freemold.Modules.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        {}

        //스탠다드몰드 관리자 제품리스트
        public IQueryable<AdminProductDetailModel> GetProductView()
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


    }
}
