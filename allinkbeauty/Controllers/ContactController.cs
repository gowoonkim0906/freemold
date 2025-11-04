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

            List<TbCode> product_category = new List<TbCode>();
            product_category = await _codeService.GetCodeList("p_category");

            List<TbCode> timeline = new List<TbCode>();
            timeline = await _codeService.GetCodeList("timeline");

            List<TbCode> budget_range = new List<TbCode>();
            budget_range = await _codeService.GetCodeList("b_range");

            List<TbCode> order_quantity = new List<TbCode>();
            order_quantity = await _codeService.GetCodeList("o_quantity");


            ViewBag.countrylist = countrylist;
            ViewBag.productcategory = product_category;
            ViewBag.timeline = timeline;
            ViewBag.budgetrange = budget_range;
            ViewBag.orderquantity = order_quantity;

            return View();
        }


        public async Task<JsonResult> ContactInsert(TB_ALLINKBEAUTY_CONTACT item)
        {

            item.RegIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";

            string result = await _allinkbeautyService.ContactInsert(item);
            return Json(new { Item1 = result });

        }
    }
}
