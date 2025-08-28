using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Repositories
{

    public class BeautyRepository : BaseRepository
    {
        public BeautyRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        { }


        public IQueryable<ProductModel> GetProductList()
        {
            try
            {
                var query = from p in _appdbcontext.ProductLists
                            join c in _appdbcontext.Member1s on p.MemberUid equals c.Uid
                            select new ProductModel
                            {
                                PImg1 = p.PImg1,
                                Uid = c.Uid,
                                CompanyName = c.CompanyName,
                                CompanyNameE = c.CompanyNameE,
                                PCode = p.PCode,
                                PHit = p.PHit,
                                PCapacity = p.PCapacity,
                                PCapUnit = p.PCapUnit,
                                PQuality = p.PQuality,
                                QnaUse = c.QnaUse,
                                ProdType = p.ProdType,
                                Visit = p.Visit,
                                UpCat = p.UpCat,
                                POrigin = p.POrigin,
                                IsRefill = p.IsRefill,
                                IsPcr = p.IsPcr,
                                IsMove = p.IsMove,
                                Deleted = p.Deleted,
                                PApproval = p.PApproval,
                                PUse = p.PUse,
                                Approval = c.Approval,
                                ApprovalView = c.ApprovalView,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                PRegdate = p.PRegdate
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
