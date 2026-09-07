using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
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
        private readonly BannerRepository _bannerRepository;

        public BannerService(AppDbContext appdbcontext, BannerRepository bannerRepository)
        {

            this._appdbcontext = appdbcontext;
            this._bannerRepository = bannerRepository;
        }

        public async Task<List<TB_BANNER>> BannerList(List<string> bannerIds)
        {

            var today = DateTime.Today;

            var query = _bannerRepository.GetBannerList().AsNoTracking()
                        .Where(
                                        x => x.Deleted == "N"
                                            && x.isUse == "Y"
                                            && x.bType == "N"
                                            && (x.BannerUnlimit == "Y" || (x.sDate != null && x.eDate != null && x.sDate <= today && x.eDate >= today))
                                            && bannerIds.Contains(x.bIdx)
                                     )
                              .OrderByDescending(x => x.Idx)  //Idx 내림차순
                              .Take(3)                        //상위 3개만
                              .AsNoTracking();



            var list = await query.ToListAsync();

            return list;

        }



        //배너 설정 리스트
        public async Task<List<BannerSettingModel>> BannerSettingList()
        {
            var query = _bannerRepository.GetBannerSettingList().AsNoTracking();
            //.OrderBy(x => x.bcord )  //Idx 내림차순
            //.ThenBy(x => x.ord1)
            //.ThenBy(x => x.ord2);



            var list = await query.ToListAsync();

            return list;

        }


        public async Task<List<BannerSettingCategoryModel>> BannerSettingCategoryList()
        {
            var query = _bannerRepository.GetBannerSettingCategoryList().AsNoTracking()
            .OrderBy(x => x.aord)  //Idx 내림차순
            .ThenBy(x => x.acode)
            .ThenBy(x => x.bord)
            .ThenBy(x => x.bcode)
            .ThenBy(x => x.cord)
            .ThenBy(x => x.ccode);



            var list = await query.ToListAsync();

            return list;

        }

        public async Task<BannerSettingModel?> BannerSettingView(int bidx)
        {
         
            return await _bannerRepository
                .GetBannerSettingList()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.banneridx == bidx);
        }

        public async Task<BannerSettingCategoryModel?> BannerSettingCategoryView(string bcode)
        {

            return await _bannerRepository
                .GetBannerSettingCategoryList()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.code == bcode);
        }


        public async Task<string> BannerSettingSet(BannerSetSettingModel input, CancellationToken ct = default) {

            try
            {
                string result = "success";


                if (input.bgubun == "b" && input.bidx > 0)
                {
                    result = await _bannerRepository.BannerTypeUpdate(input);
                }
                else if (input.bgubun == "c" && input.bidx > 0)
                {
                    result = await _bannerRepository.BannerTypeCatUpdate(input);
                }
                else if (input.bgubun == "c" && input.bidx == 0)
                {
                    result = await _bannerRepository.BannerTypeCatInsert(input);
                }
                else {
                    result = "fail";
                }

                return result;
            }
            catch(Exception ex)
            {
                return "fail";
            }

        }

    }
}
