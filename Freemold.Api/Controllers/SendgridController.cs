using Freemold.Modules;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("PartnerCors")]
    public class SendgridController : Controller
    {
        private readonly ISendgridService _sendgridService;
        private readonly IFreemoldService _freemoldService;

        public SendgridController(ISendgridService sendgridService, IFreemoldService freemoldService)
        {
            _sendgridService = sendgridService;
            _freemoldService = freemoldService;
        }


        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] MailRequest request)
        {
            string result = await _sendgridService.SendEmailAsync(
                request.ToEmail,
                request.Subject,
                request.Content,
                request.HtmlContent
            );

            if (result == "Accepted")
            {
                return Ok(new
                {
                    ok = true,
                    message = "Email sent."
                });
            }


            return StatusCode(StatusCodes.Status502BadGateway, new
            {
                ok = false,
                message = "SendGrid send failed.",
                sendgridStatus = result
            });


        }


        [HttpPost("freemoldjoin")]
        public async Task<IActionResult> FreemoldJoinSend([FromBody] JoinMailRequest request)
        {

            JoinAuthModel joinauthmodel = new JoinAuthModel();

            joinauthmodel = await _freemoldService.JoinAuth(
                request.ConIdx,
                request.Mobile,
                request.ToEmail,
                request.AuthType,
                request.RegIP,
                request.Memberid
            );


            var res = new JoinMailReponse
            {
                ok = false,
                message = "Unknown",
                mchk = joinauthmodel.mobilechk,
                echk = joinauthmodel.emailchk
            };

            //인증번호가 있을경우면 이메일 발송
            if (joinauthmodel.authkey.Length == 6)
            {

                string result = await _sendgridService.JoinEmail(
                    request.ToEmail,
                    request.Subject,
                    request.Content,
                    request.HtmlContent,
                    joinauthmodel.authkey
                );

                res.result = result;

                //이메일 발송 성공
                if (result == "Accepted")
                {
                    res.ok = true;
                    res.message = "Email sent.";


                    return Ok(res);
                }

                //이메일 발송 실패
                res.ok = false;
                res.message = "SendGrid send failed";

                return Ok(res);
            }
            else {

                //인증번호가 없을경우면 이메일 발송 실패
                res.ok = false;
                res.message = "No Auth";

                return Ok(res);
            }


            
        }


        [HttpPost("freemoldsearch")]
        public async Task<IActionResult> FreemoldSearchSend([FromBody] PasswordSearchMailReponse request)
        {

            string result = await _sendgridService.PasswordSearchEmail(
                    request.FindLog,
                    request.ToEmail,
                    request.Subject,
                    request.Content,
                    request.HtmlContent
                );


            var res = new MailReponse();    

            res.result = result;

            //이메일 발송 성공
            if (result == "Accepted")
            {
                res.ok = true;
                res.message = "Email sent.";


                return Ok(res);
            }

            //이메일 발송 실패
            res.ok = false;
            res.message = "SendGrid send failed";

            return Ok(res);



        }

    }   
}
