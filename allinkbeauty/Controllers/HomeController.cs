using allinkbeauty.Models;
using Freemold.Modules;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace allinkbeauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllinkbeautyService _allinkbeautyService;

        public HomeController(ILogger<HomeController> logger, IAllinkbeautyService allinkbeautyService)
        {
            _logger = logger;
            _allinkbeautyService = allinkbeautyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<JsonResult> ContactUsInsert(TB_ALLINKBEAUTY_CONTACT_US item)
        {

            item.RegIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";

            string result = await _allinkbeautyService.ContactUsInsert(item);
            return Json(new { Item1 = result });

        }


        [Route("blocked")]
        public IActionResult Blocked()
        {
            string block = HttpContext.Session.GetString("block") ?? "false";
            ViewBag.ip = HttpContext.Session.GetString("ClientIp");


            if (block.ToLower() == "false")
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
