using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Runtime.Intrinsics.Arm;

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
            // 세션 사용: 반드시 app.UseSession() 이후에 이 미들웨어가 등록되어 있어야 함
            var started = context.Session.GetString("SessionStarted");
            if (string.IsNullOrEmpty(started))
            {
                context.Session.SetString("SessionStarted", "true");

                // 1) 클라이언트 IP 추출 (프록시 고려: X-Forwarded-For의 첫 IP)
                var clientIp = GetClientIp(context);

                // 2) 요청 범위 공유(Items) + 세션 보관(필요 최소만)
                if (!string.IsNullOrWhiteSpace(clientIp))
                {
                    context.Items["ClientIp"] = clientIp;
                    context.Session.SetString("ClientIp", clientIp);
                }

                // 3) 차단 여부 검사 (실패 내성: 예외시 통과 또는 기본값 false)
                bool blocked = false;
                try
                {
                    if (!string.IsNullOrWhiteSpace(clientIp))
                        blocked = allinkbeautyService.BlockIp(clientIp);
                }
                catch
                {
                    // TODO: 로깅 권장. 정책상 실패시 통과/차단 선택
                    blocked = false;
                }

                context.Session.SetString("block", blocked.ToString());

                if (blocked)
                {
                    context.Response.Redirect("/blocked");
                    return;
                }
                else
                {

                    var connect = await allinkbeautyService.AllinKVisitorInsert(clientIp ?? "");

                    if(connect.Idx <= 0)
                    {
                        context.Session.SetString("block", "false");
                        context.Response.Clear(); // 혹시 이전에 쓴 바디가 있으면 제거
                        context.Response.StatusCode = StatusCodes.Status302Found;
                        context.Response.Headers["Location"] = "/blocked";
                        await context.Response.CompleteAsync();
                        return;
                    }


                }

                // (선택) 4) 지오IP가 필요하면 비차단 보조 로직으로
                // _ = EnrichGeoAsync(context, httpFactory); // fire-and-forget, 실패 무시
            }

            await _next(context);
        }


        private static string? GetClientIp(HttpContext ctx)
        {
            // X-Forwarded-For: "client, proxy1, proxy2" → 첫 번째가 실제 클라이언트
            var xff = ctx.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            var forwarded = xff?.Split(',').FirstOrDefault()?.Trim();
            if (!string.IsNullOrWhiteSpace(forwarded))
                return forwarded;

            // 프록시가 없으면 RemoteIpAddress 사용
            return ctx.Connection.RemoteIpAddress?.MapToIPv4().ToString();
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
