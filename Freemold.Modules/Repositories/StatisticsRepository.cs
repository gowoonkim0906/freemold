using Freemold.Modules.Common;
using Freemold.Modules.Models;

namespace Freemold.Modules.Repositories
{
    public class StatisticsRepository: BaseRepository
    {
        public StatisticsRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        {}


        public IQueryable<TbConnectionSm> GetConnectionSms()
        {
            try
            {
                var query = _appdbcontext.TbConnectionSms;

                return query;
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<StatisticsCountryModel> GetConnectionCountrySms()
        {
            try
            {
                var query = (
                    from i in _appdbcontext.TbConnectionSms
                    join p in _appdbcontext.TbCodes
                    on i.CCode equals p.Code 
                    where p.Sort == "국가코드_국문"
                    select new StatisticsCountryModel
                    {
                        CCode = i.CCode,
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
