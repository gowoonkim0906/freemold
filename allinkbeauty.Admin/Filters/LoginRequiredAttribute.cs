using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace allinkbeauty.Admin.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var admin = session.GetString("admin");

            // 세션이 없으면 로그인 페이지로 이동
            if (string.IsNullOrEmpty(admin))
            {
                context.Result = new RedirectToActionResult("", "Home", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
