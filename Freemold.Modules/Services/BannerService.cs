using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Freemold.Modules.Services
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _appdbcontext;

        public BannerService(AppDbContext appdbcontext)
        {

            this._appdbcontext = appdbcontext;
        }
        public async Task<List<TbBanner>> BannerList(List<string> bannerIds)
        {

            var today = DateTime.Today;


            var query = _appdbcontext.TbBanners
                              .Where( 
                                        x => x.Deleted == "N"
                                            && x.IsUse == "Y"
                                            && x.BType == "N"
                                            && (x.BannerUnlimit == "Y" || (x.SDate != null && x.EDate != null && x.SDate <= today && x.EDate >= today))
                                            && bannerIds.Contains(x.BIdx)
                                     )
                              .OrderByDescending(x => x.Idx) // Idx 내림차순
                              .Take(3)                       // 상위 3개만
                              .AsNoTracking();

            var sql = query.ToQueryString();

            var list = await query.ToListAsync();

            return list;

        }
    }

}
