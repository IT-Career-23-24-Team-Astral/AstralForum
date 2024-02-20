using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.Extensions;

namespace AstralForum.Services
{
    public class AstralForumAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (!authorizeResult.Succeeded)
            {
                var referer = context.Request.Headers["Referer"];

                if (!referer.Contains("&authenticate"))
                {
                    context.Response.Redirect(referer + "&authenticate");
                }

                return;
            }
            else
            {
                await next(context);
            }
        }
    }
}
