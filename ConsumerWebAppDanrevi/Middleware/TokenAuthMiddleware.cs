using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;

namespace ConsumerWebAppDanrevi.Middleware
{
    public class TokenAuthMiddleware 
    {

        private readonly RequestDelegate _next;
        

        public TokenAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var loginRoute = "/Auth/Login";
           
            if(!context.Session.Keys.Any(x => x == "token") &&  context.Request.Path.Value != loginRoute)
            {
                context.Response.Redirect(loginRoute);
                
                return;
            }   
          
            await _next(context);
        }
       
    }
}
