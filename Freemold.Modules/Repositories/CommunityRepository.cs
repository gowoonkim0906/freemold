using Freemold.Modules.Common;
using Freemold.Modules.Models;

namespace Freemold.Modules.Repositories
{
    public class CommunityRepository : BaseRepository
    {
        public CommunityRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        {}

        public IQueryable<InquiryModel> GetInquiryList()
        {
            try
            {
                var query = (
                    from i in _appdbcontext.TbSmInquiries
                    join p in _appdbcontext.ProductLists
                        on i.PIdx equals p.PROD_UID into prodGroup
                    from prod in prodGroup.DefaultIfEmpty()
                    select new InquiryModel
                    {
                        Idx = i.Idx,
                        PIdx = i.PIdx,
                        Name = i.Name,
                        Email = i.Email,
                        Company = i.Company,
                        Inquiry = i.Inquiry,
                        RegCountry = i.RegCountry,
                        RegDate = i.RegDate,
                        ProductName = prod != null ? prod.P_CODE : "직접문의"
                    }
                );

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<TbSmInquiry> GetInquiryView()
        {
            try
            {
                var query = _appdbcontext.TbSmInquiries;

                return query;
            }
            catch
            {
                throw;
            }
        }


    }
}
