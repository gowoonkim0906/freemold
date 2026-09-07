using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Freemold.Admin.Controllers
{
    public class BannerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBannerService _bannerService;

        public BannerController(ILogger<HomeController> logger, IBannerService bannerService)
        {
            _logger = logger;
            _bannerService = bannerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Management()
        {
            List<BannerSettingModel> list1 = new List<BannerSettingModel>();
            list1 = await _bannerService.BannerSettingList();

            List<BannerSettingCategoryModel> list2 = new List<BannerSettingCategoryModel>();
            list2 = await _bannerService.BannerSettingCategoryList();

            ViewBag.bannerlist = list1;
            ViewBag.bannercategorylist = list2;


            return View();
        }

        public IActionResult Management_Test()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> Setting()
        {

            List<BannerSettingModel> list1 = new List<BannerSettingModel>();
            list1 = await _bannerService.BannerSettingList();

            List<BannerSettingCategoryModel> list2 = new List<BannerSettingCategoryModel>();
            list2 = await _bannerService.BannerSettingCategoryList();

            ViewBag.bannerlist = list1;
            ViewBag.bannercategorylist = list2;

            return View();
        }


        public ActionResult AjaxSetBannerModal()
        {
            return View();
        }


        public async Task<IActionResult> AjaxSetBannerSettingModal(string bgubun , int bidx , string bbcode)
        {

            var bannersettingmodel = new BannerSettingModel();
            var bannersettingcategorymodel = new BannerSettingCategoryModel();


            if (bgubun == "b")
            {
                bannersettingmodel = await _bannerService.BannerSettingView(bidx);
                if (bannersettingmodel == null) bannersettingmodel = new BannerSettingModel();
            }


            if (bgubun == "c")
            {
                bannersettingcategorymodel = await _bannerService.BannerSettingCategoryView(bbcode);
                if (bannersettingcategorymodel == null) bannersettingcategorymodel = new BannerSettingCategoryModel();
            }



            ViewBag.bannersettinginfo = bannersettingmodel;
            ViewBag.bannersettingcategorymodel = bannersettingcategorymodel;
            ViewBag.bannergubun = bgubun;

            return View();
        }


        [HttpPost]
        public async Task<JsonResult> AjaxSetSetting(BannerSetSettingModel item)
        {
            try
            {
                var result = await _bannerService.BannerSettingSet(item);


                return Json(new { item1 = result });

            }
            catch
            {
                return Json(new { item1 = "fail" });
            }
        }
    }
}
