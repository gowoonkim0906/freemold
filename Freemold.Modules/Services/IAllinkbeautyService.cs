using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface IAllinkbeautyService
    {
        List<StatisticsModel> StatisticsList(DateTime? sDate = null, DateTime? eDate = null);
        List<StatisticsHourModel> StatisticsHourList(DateTime? sDate = null, DateTime? eDate = null);
        List<StatisticsRefererModel> StatisticsRefererList(DateTime? sDate = null, DateTime? eDate = null);
        List<StatisticsCountryModel> StatisticsCountryList(DateTime? sDate = null, DateTime? eDate = null);
        List<InquiryModel> InquiryList();
        InquiryViewModel InquiryView(int idx);
        AdminProductDetailModel InquiryProductView(int idx);
        List<AdminProductModel> ProductList();
        List<AdminProductModel> KProductList();
        List<AdminProductModel> CProductList();
        ProductDetailModel ProductView(int ProdUid);
        Task<string> ProductUpdate(ProductSaveModel productSaveModel, string delete_existing_ids, string image_order, List<IFormFile> files);
        Task<string> ProductViewUpdate(long ProdUid, string PUseSt);
        Task<List<KbeautyProductModel>> KbeautyProductList(string category1, string category2, string category3, string volume1, string volume2, CancellationToken ct = default);
        Task<List<KbeautyProductModel>> uspKbeautyProductList(ProductSearchModel ps, CancellationToken ct = default);
        Task<KbeautyProductModel> KbeautyProductView(long produid, CancellationToken ct = default);
        Task<string> ContactInsert(TB_ALLINKBEAUTY_CONTACT input, CancellationToken ct = default);
        Task<string> ContactUsInsert(TB_ALLINKBEAUTY_CONTACT_US input, CancellationToken ct = default);
        Task<List<ContactModel>> ContactList(CancellationToken ct = default);
        Task<List<TB_ALLINKBEAUTY_CONTACT_US>> ContactUsList(CancellationToken ct = default);
        Task<UspconnectionModel> AllinKVisitorInsert(string regip);

        
        bool BlockIp(string ip);
    }
}
