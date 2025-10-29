using Freemold.Modules.Models;
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
        Task<KbeautyProductModel> KbeautyProductView(long produid, CancellationToken ct = default);
        bool BlockIp(string ip);
    }
}
