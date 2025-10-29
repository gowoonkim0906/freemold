using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class CommonController : Controller
    {
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
    }
}
