using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;
using ConsumerWebAppDanrevi.Services.Contracts;

namespace ConsumerWebAppDanrevi.Middleware
{
    public class TokenAuthMiddleware 
    {

        private readonly RequestDelegate _next;
        private readonly ITokenAuth _tokenAuth;

        public TokenAuthMiddleware(RequestDelegate next, ITokenAuth tokenAuth)
        {
            _next = next;
            _tokenAuth = tokenAuth;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var loginRoute = "/Auth/Login";
           
            if(!_tokenAuth.IsAuthenticated() &&  context.Request.Path.Value != loginRoute)
            {
                context.Response.Redirect(loginRoute);
                
                return;
            }   
         
            await _next(context);
        }
       
    }
}
