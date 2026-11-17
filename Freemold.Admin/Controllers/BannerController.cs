using Freemold.Modules;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Freemold.Admin.Controllers
{
    public class BannerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _rootPath;
        private readonly IBannerService _bannerService;
        private readonly IMemberService _memberService;


        public BannerController(ILogger<HomeController> logger, IOptions<StorageOptions> options, IBannerService bannerService, IMemberService memberService)
        {
            _logger = logger;
            _rootPath = options.Value.RootPath;
            _bannerService = bannerService;
            _memberService = memberService;
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


        public async Task<ActionResult> AjaxSetBannerModal(int banneridx , int idx = 0 )
        {
            BannerManagementModel item = new BannerManagementModel();

            item = await _bannerService.TypeBannerView(banneridx);


            BannerResponseModel bannerinfo = new BannerResponseModel();

            bannerinfo = await _bannerService.GetBanner(banneridx, idx);
            
            
            ViewBag.bannertype = item;
            ViewBag.bannerinfo = bannerinfo;
            ViewBag.rootpath = _rootPath;



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


        [HttpPost]
        public async Task<JsonResult> AjaxGetTypeBanner(int bidx,  int page = 1, int pagesize = 10, string searchtype = "")
        {
            try
            {
                page = Math.Max(1, page);
                pagesize = Math.Clamp(pagesize, 1, 100);

                var result = await _bannerService.TypeBannerList(bidx, page, pagesize, searchtype);


                return Json(new { items = result.items, totalCount = result.totalcount });

            }
            catch
            {
                return Json(new { items = Array.Empty<object>(), totalCount = 0 });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AjaxDeleteTypeBanner(BannerDeleteRequestModel item)
        {
            try
            {
                if (item.idx == null || item.idx.Count == 0)
                {
                    return Json(new { items = "fail" });
                }

                string regIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";

                item.regIp = regIp;

                var result = await _bannerService.TypeBannerDelete(item);


                return Json(new { items = result });

            }
            catch
            {
                return Json(new { items = "fail" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AjaxGetSearchCompany(string companyname)
        {
            try
            {

                var result = await _memberService.CompanyList(companyname);


                return Json(new { items = result });

            }
            catch
            {
                return Json(new { items = "fail" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AjaxGetBannerCnt(int bidx)
        {
            try
            {

                var result = await _bannerService.TypeBannerCnt(bidx);


                return Json(new { items = result });

            }
            catch
            {
                return Json(new { items = "fail" });
            }
        }


        [HttpPost]
        public async Task<JsonResult> AjaxSetBanner([FromForm] BannerSetRequestModel item)
        {
            try
            {
                var result = "fail";

                if (item.idx > 0)
                {
                    result = await _bannerService.ModifyBanner(item);
                }
                else {
                    result = await _bannerService.SetBanner(item);
                    
                }


                return Json(new { items = result });

            }
            catch
            {
                return Json(new { items = "fail" });
            }
        }
        
    }
}
