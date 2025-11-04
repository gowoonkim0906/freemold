using Freemold.Modules;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class CommonController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ICodeService _codeService;
        private readonly IAllinkbeautyService _allinkbeautyService;

        public CommonController(ILogger<HomeController> logger, ICodeService codeService, IAllinkbeautyService allinkbeautyService)
        {
            _logger = logger;
            _codeService = codeService;
            _allinkbeautyService = allinkbeautyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjaxPagination(int page , int pagesize, int totalcount, int pageblock)
        {

            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;

            return View();

        }

        public async Task<JsonResult> ProductList(int page = 1, string acode = "A001", string category1 = "", string category2 = "", string volume1 = "", string volume2 = "")
        {
            int pagesize = 16;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;


            List<KbeautyProductModel> list = new List<KbeautyProductModel>();
            list = await _allinkbeautyService.KbeautyProductList(acode, category1, category2, volume1, volume2); //프리몰드 A001

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();


            return Json(new { item1 = "success", item2 = items, item3 = page, item4 = pagesize, item5 = totalcount });
        }

        public async Task<JsonResult> CategoryList(string ACode)
        {

            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList(ACode, "Y");

            return Json(new { Item1 = "success", Item2 = categorylist });
        }
    }
}
