using Freemold.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface IBannerService
    {
        Task<List<TB_BANNER>> BannerList(List<string> bannerIds);

        Task<List<BannerSettingModel>> BannerSettingList();

        Task<List<BannerSettingCategoryModel>> BannerSettingCategoryList();
        Task<BannerSettingModel?> BannerSettingView(int bidx);
        Task<BannerSettingCategoryModel?> BannerSettingCategoryView(string bcode);

        Task<string> BannerSettingSet(BannerSetSettingModel input, CancellationToken ct = default);
    }
}
