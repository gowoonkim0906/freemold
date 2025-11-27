using Freemold.Modules;
using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class FormulaController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICodeService _codeService;
        private readonly IAllinkbeautyService _allinkbeautyService;
        private readonly IFileService _fileService;

        public FormulaController(ILogger<HomeController> logger, ICodeService codeService, IAllinkbeautyService allinkbeautyService, IFileService fileService)
        {
            _logger = logger;
            _codeService = codeService;
            _allinkbeautyService = allinkbeautyService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(int page = 1, string code1 = "", string code2 = "")
        {
            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList("A002", "Y");

            List<TbCategory> categorylist2 = new List<TbCategory>();
            if (code1 != "")
            {
                categorylist2 = await _codeService.GetCategoryList(code1, "Y");
            }

            ViewBag.categorylist = categorylist;
            ViewBag.categorylist2 = categorylist2;

            ViewBag.filepath = SiteConfig.fileurl;
            ViewBag.page = page;
            ViewBag.code1 = code1;
            ViewBag.code2 = code2;

            return View();
        }

        public async Task<IActionResult> FormulaInfo(long produid, int page, string code1, string code2)
        {

            KbeautyProductModel productinfo = new KbeautyProductModel();

            productinfo = await _allinkbeautyService.KbeautyProductView(produid);


            ViewBag.filepath = SiteConfig.fileurl;
            ViewBag.productinfo = productinfo;
            ViewBag.page = page;
            ViewBag.code1 = code1;
            ViewBag.code2 = code2;


            return View();
        }

    }
}
