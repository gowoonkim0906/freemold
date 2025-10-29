using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class FormulaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormulaInfo()
        {
            return View();
        }
    }
}
