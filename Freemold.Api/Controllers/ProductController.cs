using Freemold.Modules.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("PartnerCors")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
