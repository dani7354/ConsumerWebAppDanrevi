using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace ConsumerWebAppDanrevi.Middleware
{
    public class CheckSessionForTokenMiddleware 
    {

        private readonly RequestDelegate _next;

        public CheckSessionForTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Session.Keys.Any(x => x == "token") && context.Request.Path.Value != "/Login")
            {
                context.Response.Redirect("/Login");
                return;
            }
           
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
       
    }
}
