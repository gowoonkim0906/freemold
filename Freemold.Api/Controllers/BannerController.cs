using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("poplist")]
        public async Task<IActionResult> PopupList([FromBody] PopupModel request)
        {
            var list =  await _bannerService.BannerList(request.idxs);

            return Ok(list);
        }
    }
}
