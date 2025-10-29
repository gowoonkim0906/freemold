using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class AboutusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllinKBeauty()
        {
            return View();
        }

        public IActionResult DesignPlanet()
        {
            return View();
        }
    }
}
