using Freemold.Modules.Models;
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
        List<AdminProductModel> KProductList();
        List<AdminProductModel> CProductList();
        ProductDetailModel ProductView(int ProdUid);
        Task<string> GetCategoryFullname(string catagory);

        bool BlockIp(string ip);
    }
}
