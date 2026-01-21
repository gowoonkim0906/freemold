using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("PartnerCors")]
    public class MemberController : Controller
    {
        private readonly IFreemoldService _freemoldService;

        public MemberController(ISendgridService sendgridService, IFreemoldService freemoldService)
        {
            _freemoldService = freemoldService;
        }


        [HttpPost("duplicate")]
        public async Task<IActionResult> DuplicateCheck([FromBody] DuplicateCheckRequest request)
        {
            var result = await _freemoldService.DuplicateCheck(request);

            return Ok(result);

        }

        
    }
}
