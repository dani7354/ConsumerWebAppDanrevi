using System;
using ConsumerWebAppDanrevi.Services.Contracts;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ConsumerWebAppDanrevi.Services
{
    public class SessionTokenAuth : ITokenAuth
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string TOKEN_HEADER_KEY = "token"; 
        public SessionTokenAuth(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetToken()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext.Session.GetString(TOKEN_HEADER_KEY) : throw new UnauthorizedAccessException();
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.Session.Keys.Any(x => x == TOKEN_HEADER_KEY);
        }
    }
}
