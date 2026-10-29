using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("PublicCors")]
    public class FreemoldController : Controller
    {
        private readonly IFreemoldService _freemoldService;


        public FreemoldController(IFreemoldService freemoldService)
        {
            this._freemoldService = freemoldService;
        }

        [HttpPost("directimportvisitor")]
        public async Task<IActionResult> FileDeleteVector([FromBody] DirectimportVisitorRequest req)
        {
            try
            {
                bool result = await _freemoldService.DirectimportVisitorSave(req);

                if (result)
                {
                    return Ok(new
                    {
                        ok = true,
                        message = "success"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status502BadGateway, new
                    {
                        ok = false,
                        message = "Python API returned error."
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = ex.Message
                });
            }

        }


        [HttpGet("dbinfo")]
        public async Task<IActionResult> DbInfo()
        {
            var result = await _freemoldService.GetDbInfo();

            return Ok(result);
        }
    }
}
