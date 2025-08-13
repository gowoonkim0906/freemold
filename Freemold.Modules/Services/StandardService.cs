using Freemold.Modules.Common;
using Freemold.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Freemold.Modules.Services
{
    public class StandardService : IStandardService
    {
        private readonly AppDbContext _appdbcontext;

        public StandardService(AppDbContext appdbcontext)
        {

            this._appdbcontext = appdbcontext;
        }

        public List<StatisticsModel> StatisticsList(DateTime? sDate = null , DateTime? eDate = null) {

            DateOnly datefrom = DateOnly.FromDateTime(sDate ?? DateTime.Today);
            DateOnly dateto= DateOnly.FromDateTime(eDate ?? DateTime.Today);

            var result = (
                from i in _appdbcontext.TbConnectionSms
                where i.InDate >= datefrom && i.InDate <= dateto
                group i by i.InDate into g
                select new StatisticsModel
                {
                    InDate = g.Key.ToString(),
                    TotalCnt = g.Count(),
                    Mobile = g.Count(x =>
                             x.UserAgent.Contains("iPhone") ||
                             x.UserAgent.Contains("Android"))

                }
            ).ToList();


            return result;
        }

        public List<InquiryModel> InquiryList()
        {
            var result = (
                    from i in _appdbcontext.TbSmInquiries
                    join p in _appdbcontext.ProductLists
                        on i.PIdx equals p.ProdUid into prodGroup
                    from prod in prodGroup.DefaultIfEmpty()
                    select new InquiryModel
                    {
                        Idx = i.Idx,
                        PIdx = i.PIdx,
                        Name = i.Name,
                        Email = i.Email,
                        Company = i.Company,
                        Inquiry = i.Inquiry,
                        RegCountry = i.RegCountry,
                        RegDate = i.RegDate,
                        ProductName = prod != null ? prod.PCode: "직접문의"
                    }
                ).OrderByDescending(m => m.Idx).ToList();

            return result;
        }

        public List<TbSmInquiry> InquiryList2()
        {

            var list = _appdbcontext.TbSmInquiries
                .Where(m => m.Deleted == "N").OrderBy(m => m.Idx).ToList();


            return list;
        }


        public InquiryViewModel InquiryView(int idx)
        {
            TbSmInquiry textresult = null;
            InquiryViewModel result = null;


            textresult = _appdbcontext.TbSmInquiries.Where(m => m.Idx == idx).FirstOrDefault() ?? null;

            if(textresult != null) {

                result = new InquiryViewModel
                {
                    pidx = textresult.PIdx,
                    name = textresult.Name,
                    company = textresult.Company,
                    inquiry = textresult.Inquiry,
                    regCountry = textresult.RegCountry,
                    RegDate = textresult.RegDate.ToString("yyyy.MM.dd")
                };
            }


            return result ?? new InquiryViewModel();
        }

        public ProductModel ProductView(int idx)
        {
            var result = (
                    from i in _appdbcontext.ProductLists
                    join p in _appdbcontext.Member1s
                        on i.MemberUid equals p.Uid
                    where i.ProdUid == idx
                    select new ProductModel
                    {
                        pimg1 = i.PImg1,
                        pname = i.PName,
                        pcode = i.PCode,
                        pcapacity = i.PCapacity,
                        pcapunit = i.PCapUnit,
                        psize = i.PSize,
                        pquality = i.PQuality,
                        memberuid = i.MemberUid,
                        company_name = p.CompanyName
                    }
                ).FirstOrDefault() ?? null;

            return result ?? new ProductModel();
        }
    }
}
