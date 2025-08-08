using Freemold.Modules.Models.EF;
using Freemold.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface IStandardService
    {
        List<StatisticsModel> StatisticsList(DateTime? sDate = null, DateTime? eDate = null);

        List<InquiryModel> InquiryList();

        List<TbSmInquiry> InquiryList2();

        InquiryViewModel InquiryView(int idx);

        ProductModel ProductView(int idx);
    }
}
