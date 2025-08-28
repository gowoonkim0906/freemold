using Freemold.Modules.Common;
using Freemold.Modules.Data;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Freemold.Modules.Services
{
    public class AllinkbeautyService : IAllinkbeautyService
    {
        private readonly MemberRepository _memberRepository;
        private readonly StatisticsRepository _statisticsRepository;
        private readonly CommunityRepository _communityRepository;
        private readonly ProductRepository _productRepository;
        private readonly CodeRepository _codeRepository;

        public AllinkbeautyService(
            MemberRepository memberRepository, 
            StatisticsRepository statisticsRepository, 
            CommunityRepository communityRepository, 
            ProductRepository productRepository,
            CodeRepository codeRepository)
        {
            this._memberRepository = memberRepository;
            this._statisticsRepository = statisticsRepository;
            this._communityRepository = communityRepository;
            this._communityRepository = communityRepository;
            this._productRepository = productRepository;
            this._codeRepository = codeRepository;
        }

        public List<StatisticsModel> StatisticsList(DateTime? sDate = null , DateTime? eDate = null) {

            DateOnly datefrom = DateOnly.FromDateTime(sDate ?? DateTime.Today);
            DateOnly dateto= DateOnly.FromDateTime(eDate ?? DateTime.Today);

            var list =
                _statisticsRepository.GetConnectionSms()
                .Where(m => m.InDate >= datefrom && m.InDate <= dateto)
                .GroupBy(m => m.InDate)
                .Select(g => new StatisticsModel
                {
                    InDate = g.Key,
                    TotalCnt = g.Count(),
                    Mobile = g.Count(x =>
                             x.UserAgent.Contains("iPhone") ||
                             x.UserAgent.Contains("Android"))
                })
                .ToList();


            return list;
        }

        public List<StatisticsHourModel> StatisticsHourList(DateTime? sDate = null, DateTime? eDate = null)
        {

            DateTime datefrom = (sDate ?? DateTime.Today).Date;
            DateTime dateto = (eDate ?? DateTime.Today).Date.AddDays(1).AddTicks(-1);

            var raw =
                _statisticsRepository.GetConnectionSms()
                .Where(m => m.RegDate >= datefrom && m.RegDate <= dateto)
                .GroupBy(m => m.RegDate.Hour)
                .Select(g => new { Hour = g.Key, TotalCnt = g.Count() }).OrderBy(g => g.Hour).ToList();



            var list = raw.Select(m => new StatisticsHourModel
            {
                sHour = $"{m.Hour:D2}시",
                TotalCnt = m.TotalCnt
            }).ToList();

            return list;
        }

        public List<StatisticsRefererModel> StatisticsRefererList(DateTime? sDate = null, DateTime? eDate = null)
        {

            DateOnly datefrom = DateOnly.FromDateTime(sDate ?? DateTime.Today);
            DateOnly dateto = DateOnly.FromDateTime(eDate ?? DateTime.Today);


            var raw = _statisticsRepository.GetConnectionSms()
                            .Where(m => m.InDate >= datefrom && m.InDate <= dateto)
                            .Select(m => m.HttpReferer ?? "")   // 최소 컬럼만
                            .AsNoTracking()
                            .ToList();         

            var list = raw
                        .Select(r => r ?? "")
                        .Select(r => r.Replace("http://", "").Replace("https://", ""))
                        .Select(r => r.Contains("standardmold.co.kr") ? "" : r)
                        .Select(r => {
                            var idx = r.IndexOf('/');
                            return idx >= 0 ? r.Substring(0, idx) : r;
                        })
                        .GroupBy(referer => referer)
                        .Select(g => new StatisticsRefererModel
                        {
                            HttpReferer = g.Key,
                            TotalCnt = g.Count()
                        })
                        .OrderByDescending(x => x.TotalCnt)
                        .ToList();


            return list;
        }


        public List<StatisticsCountryModel> StatisticsCountryList(DateTime? sDate = null, DateTime? eDate = null)
        {

            DateOnly datefrom = DateOnly.FromDateTime(sDate ?? DateTime.Today);
            DateOnly dateto = DateOnly.FromDateTime(eDate ?? DateTime.Today);


            var list = _statisticsRepository.GetConnectionCountrySms()
                            .Where(m => m.InDate >= datefrom && m.InDate <= dateto)
                            .GroupBy(m => new { m.CCode, m.CName })
                            .Select(g => new StatisticsCountryModel
                            {
                                CCode = g.Key.CCode,
                                CName = g.Key.CName,
                                TotalCnt = g.Count()
                            })
                            .OrderByDescending(x => x.TotalCnt)
                            .ToList();


            return list;
        }

        public List<InquiryModel> InquiryList()
        {
            var result = _communityRepository.GetInquiryList().OrderByDescending(m => m.Idx).ToList();

            return result;
        }

        public InquiryViewModel InquiryView(int idx)
        {
            InquiryViewModel result = new InquiryViewModel();

            if (idx <= 0) return new InquiryViewModel();


            result = _communityRepository.GetInquiryView().AsNoTracking()
                .Where(m => m.Idx == idx)
                .Select(m => new InquiryViewModel
                {
                    pidx = m.PIdx,
                    name = m.Name,
                    company = m.Company,
                    inquiry = m.Inquiry,
                    regCountry = m.RegCountry,
                    RegDate = m.RegDate.ToString("yyyy.MM.dd")
                })
                .SingleOrDefault() ?? new InquiryViewModel();


            return result;
        }

        public AdminProductDetailModel ProductView(int idx)
        {
            var result = _productRepository.GetProductView().FirstOrDefault(m => m.ProdUid == idx) ?? null;

            return result ?? new AdminProductDetailModel();
        }

        public List<AdminProductModel> KProductList()
        {
            var result = _productRepository.GetKProductList()
                        .Where(m => m.Deleted == "N" && m.PayUse == "Y" && m.Approval == "Y")
                        .OrderByDescending(m => m.PModdate).ToList();
            return result;
        }

        public List<AdminProductModel> CProductList()
        {
            var result = _productRepository.GetCProductList()
                        .Where(m => m.Deleted == "N" && m.PayUse == "Y" && m.Approval == "Y" &&  m.MemberUid == 635)
                        .OrderByDescending(m => m.PModdate).ToList();
            return result;
        }

        public async Task<string> GetCategoryFullname(string catagory)
        {

            if (string.IsNullOrWhiteSpace(catagory)) return string.Empty;

            string result = string.Empty;

            catagory = catagory.Replace(";;", ",");
            catagory = catagory.Replace(";", "");

            var tokens =  Util.strSplit(catagory, ',');
            if (tokens.Length == 0) return string.Empty;


            var seen = new HashSet<string>();
            var distinct = new List<string>(tokens.Length);
            foreach (var t in tokens)
                if (seen.Add(t)) distinct.Add(t);

            var joined = string.Join(",", tokens); // "1,2,3"

            return await _codeRepository.GetCategoryFullname(joined);
        }

        public bool BlockIp(string ip)
        {
            var result = false;

            try
            {
                var cnt = _memberRepository.GetBlockIp().AsNoTracking()
                          .Where(m => m.BlockIp == ip).Count();

                if (cnt > 0)
                {
                    return true; //이미 차단된 아이피
                }
                else
                {
                    return false;
                }
            }
            catch {

                return true;
            }
            

        }
    }
}
