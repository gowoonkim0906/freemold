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
                            join c in _appdbcontext.Member1 on p.MEMBER_UID equals c.UID
                            select new ProductModel
                            {
                                PImg1 = p.P_IMG1,
                                Uid = c.UID,
                                CompanyName = c.COMPANY_NAME,
                                CompanyNameE = c.COMPANY_NAME_E,
                                PCode = p.P_CODE,
                                PHit = p.P_HIT,
                                PCapacity = p.P_CAPACITY,
                                PCapUnit = p.P_CAP_UNIT,
                                PQuality = p.P_QUALITY,
                                QnaUse = c.QNA_USE,
                                ProdType = p.ProdType,
                                Visit = p.Visit,
                                UpCat = p.UpCat,
                                POrigin = p.P_ORIGIN,
                                IsRefill = p.isRefill,
                                IsPcr = p.isPCR,
                                IsMove = p.isMove,
                                Deleted = p.Deleted,
                                PApproval = p.P_APPROVAL,
                                PUse = p.P_USE,
                                Approval = c.APPROVAL,
                                ApprovalView = c.APPROVAL_VIEW,
                                StartDate = c.START_DATE,
                                EndDate = c.END_DATE,
                                PRegdate = p.P_REGDATE
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
