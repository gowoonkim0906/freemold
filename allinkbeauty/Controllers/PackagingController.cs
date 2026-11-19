using Freemold.Modules;
using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class PackagingController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICodeService _codeService;
        private readonly IAllinkbeautyService _allinkbeautyService;
        private readonly IFileService _fileService;

        public PackagingController(ILogger<HomeController> logger, ICodeService codeService, IAllinkbeautyService allinkbeautyService, IFileService fileService)
        {
            _logger = logger;
            _codeService = codeService;
            _allinkbeautyService = allinkbeautyService;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index(int page = 1, string code1 = "", string code2 = "", string volume1 = "", string volume2 = "")
        {
            List<TB_CATEGORY> categorylist = new List<TB_CATEGORY>();
            categorylist = await _codeService.GetCategoryList("A001", "Y");

            List<TB_CATEGORY> categorylist2 = new List<TB_CATEGORY>();
            if(code1 != "") {
                categorylist2 = await _codeService.GetCategoryList(code1, "Y");
            }

            List<TB_CODE> codelist = new List<TB_CODE>();
            codelist = await _codeService.GetCodeList("용량");


            ViewBag.categorylist = categorylist;
            ViewBag.categorylist2 = categorylist2;
            ViewBag.codelist = codelist;

            ViewBag.filepath = SiteConfig.fileurl;
            ViewBag.page = page;
            ViewBag.code1 = code1;
            ViewBag.code2 = code2;
            ViewBag.volume1 = volume1;
            ViewBag.volume2 = volume2;

            return View();
        }


        public async Task<IActionResult> PackagingInfo(long produid, int page, string code1, string code2, string volume1, string volume2)
        {
            
            KbeautyProductModel productinfo = new KbeautyProductModel();

            productinfo =  await _allinkbeautyService.KbeautyProductView(produid);


            ViewBag.productinfo = productinfo;  
            ViewBag.page = page;
            ViewBag.code1 = code1;
            ViewBag.code2 = code2;    
            ViewBag.volume1 = volume1;  
            ViewBag.volume2 = volume2;
            ViewBag.filepath = SiteConfig.fileurl;

            return View();
        }

    }
}
