using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;
using standardmold.Admin.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace standardmold.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllinkbeautyService _allinkbeautyService;
        private readonly CodeRepository _codeRepository;

        public HomeController(ILogger<HomeController> logger, IAllinkbeautyService allinkbeautyService)
        {
            _logger = logger;
            _allinkbeautyService = allinkbeautyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Statistics(DateTime? sDate = null, DateTime? eDate = null) {

            List<StatisticsModel> list1 = new List<StatisticsModel>();
            List<StatisticsHourModel> list2 = new List<StatisticsHourModel>();
            List<StatisticsRefererModel> list3 = new List<StatisticsRefererModel>();
            List<StatisticsCountryModel> list4 = new List<StatisticsCountryModel>();
            
            list1 = _allinkbeautyService.StatisticsList(sDate, eDate);
            list2 = _allinkbeautyService.StatisticsHourList(sDate, eDate);
            list3 = _allinkbeautyService.StatisticsRefererList(sDate, eDate);
            list4 = _allinkbeautyService.StatisticsCountryList(sDate, eDate);

            int datatotlacnt = list1.Sum(x => x.TotalCnt);
            int datamobile = list1.Sum(x => x.Mobile);
            int datapc = datatotlacnt - datamobile;

            ViewBag.datatotlacnt = datatotlacnt;
            ViewBag.datamobile = datamobile;
            ViewBag.datapc = datatotlacnt - datamobile;
            ViewBag.datelist = list1;
            ViewBag.hourlist = list2;
            ViewBag.hourtotal = list2.Sum(x => x.TotalCnt);
            ViewBag.refererlist = list3;
            ViewBag.countrylist = list4;

            return View();
        }

        public IActionResult InquiryList(int page = 1 ) {

            int pagesize = 10;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;



            List<InquiryModel> list = new List<InquiryModel>();
            list = _allinkbeautyService.InquiryList();

            totalcount = list == null ? 0 : list.Count;
            list = list?.Skip(pageno).Take(pagesize).ToList();


            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;

            return View(list);
        }


        public IActionResult KProductList(int page = 1)
        {
            int pagesize = 10;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;

            List<AdminProductModel> list = new List<AdminProductModel>();
            list = _allinkbeautyService.KProductList();

            totalcount = list == null ? 0 : list.Count;
            list = list?.Skip(pageno).Take(pagesize).ToList();


            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.list = list;

            return View();
        }

        public async Task<IActionResult> CProductList(int page = 1)
        {
            int pagesize = 30;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;

            List<AdminProductModel> list = new List<AdminProductModel>();
            list = _allinkbeautyService.CProductList();

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();


            var keys = items.Select(x => x.PCategory ?? string.Empty)
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .Distinct()
                    .ToList();


            var tasks = keys.ToDictionary(k => k, k => _allinkbeautyService.GetCategoryFullname(k));
            await Task.WhenAll(tasks.Values);

            var catMap = tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result);

            foreach (var it in items)
            {
                if (!string.IsNullOrEmpty(it.PCategory) &&
                    catMap.TryGetValue(it.PCategory, out var fullName))
                {
                    it.PCategoryName = fullName;
                }
            }

            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;
            ViewBag.list = items;

            return View();
        }



        public JsonResult InquiryView(int idx) {

            InquiryViewModel result1 = _allinkbeautyService.InquiryView(idx);

            AdminProductDetailModel result2 = null;

            if (result1 != null) {
                result2 = _allinkbeautyService.ProductView(result1.pidx);
            }

            return Json(new { Item1 = "success", Item2 = result1, Item3 = result2 });

        }

        [Route("blocked")]
        public IActionResult Blocked()
        {
            string block = HttpContext.Session.GetString("block") ?? "false";
            ViewBag.ip = HttpContext.Session.GetString("ClientIp");


            if(block.ToLower() == "false")
            {
                return Redirect("/");
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
