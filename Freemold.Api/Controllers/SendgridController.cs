using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendgridController : Controller
    {
        private readonly ISendgridService _sendgridService;

        public SendgridController(ISendgridService sendgridService)
        {
            _sendgridService = sendgridService;
        }


        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] MailRequest request)
        {
            await _sendgridService.SendEmailAsync(
                request.ToEmail,
                request.Subject,
                request.Content,
                request.HtmlContent
            );
            return Ok("Email sent.");
        }
    }
}
