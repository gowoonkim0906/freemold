using Freemold.Modules.Common;
using Freemold.Modules.Models;

namespace Freemold.Modules.Repositories
{
    public class StatisticsRepository: BaseRepository
    {
        public StatisticsRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        {}


        public IQueryable<TB_CONNECTION_ALLINKBEAUTY> GetConnectionAllInKBeauty(DateTime? sDate = null, DateTime? eDate = null)
        {
            try
            {
                sDate = (sDate ?? DateTime.Today).Date;
                eDate = ((eDate ?? DateTime.Today).Date).AddDays(1).AddTicks(-1);

                var query = _appdbcontext.TB_CONNECTION_ALLINKBEAUTY.Where(m => m.InDate >= sDate && m.InDate <= eDate);

                return query;
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<StatisticsCountryModel> GetConnectionCountryAllInKBeauty(DateTime? sDate = null, DateTime? eDate = null)
        {
            try
            {
                sDate = (sDate ?? DateTime.Today).Date;
                eDate = ((eDate ?? DateTime.Today).Date).AddDays(1).AddTicks(-1);

                var query = (
                    from i in _appdbcontext.TB_CONNECTION_ALLINKBEAUTY
                    join p in _appdbcontext.TbCodes
                    on i.cCode equals p.Code 
                    where p.Sort == "국가코드_국문" && i.InDate >= sDate && i.InDate <= eDate
                    select new StatisticsCountryModel
                    {
                        CCode = i.cCode,
                        CName = p.Name,
                        InDate = i.InDate
                    }
                );

                return query;
            }
            catch
            {
                throw;
            }
        }
    }
}
