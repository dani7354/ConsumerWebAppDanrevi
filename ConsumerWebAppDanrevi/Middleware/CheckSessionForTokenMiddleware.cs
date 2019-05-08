using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;

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
            var publicPaths = new List<string>() // indlæses i constructoren
            {
                "/Login",
                "/Login/Login"
            };
            if(!context.Session.Keys.Any(x => x == "token") &&  !publicPaths.Contains(context.Request.Path.Value))
            {
                context.Response.Redirect("/Login");
                return;
            }   
           
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
       
    }
}
