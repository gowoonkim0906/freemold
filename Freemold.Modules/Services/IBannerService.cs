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
        Task<List<TB_BANNER>> BannerList(List<int> bannerIds);

        Task<List<BannerSettingModel>> BannerSettingList();

        Task<List<BannerSettingCategoryModel>> BannerSettingCategoryList();
        Task<BannerSettingModel?> BannerSettingView(int bidx);
        Task<BannerSettingCategoryModel?> BannerSettingCategoryView(string bcode);
        Task<string> BannerSettingSet(BannerSetSettingModel input, CancellationToken ct = default);
        Task<PagedResult<BannerResponseModel>> TypeBannerList(int bidx, int page, int pagesize, string searchtype);
        Task<string> TypeBannerDelete(BannerDeleteRequestModel item, CancellationToken ct = default);
        Task<BannerCntModel> TypeBannerCnt(int bidx);
        Task<BannerManagementModel> TypeBannerView(int bidx);
        Task<string> SetBanner(BannerSetRequestModel item, CancellationToken ct = default);
        Task<string> ModifyBanner(BannerSetRequestModel item, CancellationToken ct = default);
        Task<BannerResponseModel> GetBanner(int banneridx, int idx);
        Task<PagedResult<BannerSearchDataModel>> SearchBannerList(BannerSearchModel bannersearchmodel);
        Task<BannerTotalCountModel> GetBannerTotalCount();
        Task<List<BannerTypeCountModel>> GetBannerTypeTotal();
        Task<BannerCategoryCountModel> GetBannerCategoryTotal();
    }
}
