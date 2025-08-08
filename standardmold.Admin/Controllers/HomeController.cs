using Freemold.Modules.Models.EF;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;
using standardmold.Admin.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace standardmold.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStandardService _standardService;

        public HomeController(ILogger<HomeController> logger, IStandardService standardService)
        {
            _logger = logger;
            _standardService = standardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Statistics(DateTime? sDate = null, DateTime? eDate = null) {

            List<StatisticsModel> list = new List<StatisticsModel>();

            list = _standardService.StatisticsList(sDate, eDate);

            int datatotlacnt = list.Sum(x => x.TotalCnt);
            int datamobile = list.Sum(x => x.Mobile);
            int datapc = datatotlacnt - datamobile;

            ViewBag.datatotlacnt = datatotlacnt;
            ViewBag.datamobile = datamobile;
            ViewBag.datapc = datatotlacnt - datamobile;
            ViewBag.datelist = list;

            return View(list);
        }


        public IActionResult InquiryList(int page = 1 ) {

            int pagesize = 10;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;



            List<InquiryModel> list = new List<InquiryModel>();
            list = _standardService.InquiryList();

            totalcount = list == null ? 0 : list.Count;
            list = list?.Skip(pageno).Take(pagesize).ToList();


            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;

            return View(list);
        }

        public JsonResult InquiryView(int idx) {

            InquiryViewModel result1 = _standardService.InquiryView(idx);

            ProductModel result2 = null;

            if (result1 != null) {
                result2 = _standardService.ProductView(result1.pidx);
            }

            return Json(new { Item1 = "success", Item2 = result1, Item3 = result2 });

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
