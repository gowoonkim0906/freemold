using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace allinkbeauty.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var http = context.HttpContext;

            // /blocked 자체는 예외(무한 루프 방지)
            if (!http.Request.Path.StartsWithSegments("/blocked"))
            {
                var blocked = http.Session?.GetString("block") ?? "false";
                if (blocked.ToLower() == "true")
                {
                    context.Result = new RedirectResult("/blocked"); // 302
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
