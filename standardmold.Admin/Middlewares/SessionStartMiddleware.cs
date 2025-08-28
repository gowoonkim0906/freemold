using Microsoft.AspNetCore.Http;
using System.Net;
using Freemold.Modules.Models;
using Freemold.Modules.Services;

namespace Middlewares
{

    public class SessionStartMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SessionStartMiddleware> _logger;

        public SessionStartMiddleware(RequestDelegate next,
                                      IHttpClientFactory httpClientFactory,
                                      ILogger<SessionStartMiddleware> logger)
        {
            _next = next;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IAllinkbeautyService allinkbeautyService)
        {
            // 세션이 준비되어 있어야 함 (Program.cs에서 app.UseSession() 이후에 등록)
            var started = context.Session.GetString("SessionStarted");
            if (string.IsNullOrEmpty(started))
            {
                context.Session.SetString("SessionStarted", "true");
                //context.Session.SetString("UserRole", "Guest");
                //context.Session.SetInt32("LoginCount", 0);

                // 필요시: 사용자별 초기 데이터 로딩/언어 설정/트래킹 등
                // context.Session.SetString("Lang", "ko");

                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                var http = _httpClientFactory.CreateClient();
                var url = $"https://ipinfo.io/json";

                var ipInfo = await http.GetFromJsonAsync<IpInfo>(url, cancellationToken: cts.Token);

                if (ipInfo != null)
                {
                    // 필요 시 세션/Items에 저장 (세션은 용량/빈도 고려)
                    context.Items["ClientIp"] = ipInfo.ip;
                    context.Items["ClientGeo"] = ipInfo; // 요청 수명 내 재사용

                    context.Session.SetString("ClientIp", ipInfo.ip ?? "");

                    bool ipcheck = allinkbeautyService.BlockIp(ipInfo.ip ?? ""); // 차단 여부 확인
               
                    context.Session.SetString("block", ipcheck.ToString());

                    if (ipcheck)
                    {
                        // 차단된 IP인 경우
                        context.Response.Redirect("/blocked");
                        return;
                    }
                }
            }

            await _next(context);
        }




        private class IpInfo
        {
            public string? ip { get; set; }
            public string? city { get; set; }
            public string? region { get; set; }
            public string? country { get; set; }
            public string? loc { get; set; }      // "lat,lon"
            public string? org { get; set; }      // ISP/ASN
            public string? postal { get; set; }
            public string? timezone { get; set; }
            public string? readme { get; set; }
        }
    }
}
