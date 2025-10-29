using Freemold.Modules;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IAllinkbeautyService _allinkbeautyService;
        private readonly ICodeService _codeService;

        public ContactController(ILogger<ContactController> logger, IAllinkbeautyService allinkbeautyService, ICodeService codeService)
        {
            _logger = logger;
            _allinkbeautyService = allinkbeautyService;
            _codeService = codeService;
        }


        public async Task<IActionResult> Index()
        {
            List<TbCode> countrylist = new List<TbCode>();
            countrylist = await _codeService.GetCodeList("국가코드_영문");


            ViewBag.countrylist = countrylist;

            return View();
        }
    }
}
