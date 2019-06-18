    using System;
using ConsumerWebAppDanrevi.Services.Contracts;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Models.Login;

namespace ConsumerWebAppDanrevi.Services
{
    public class SessionTokenAuth : ITokenAuth
    {
        private const string TOKEN_SESSION_KEY = "token";
        private const string USERNAME_SESSION_KEY = "name";
        private const string EMAIL_SESSION_KEY = "email";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionTokenAuth(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ClearSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public string GetToken()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext.Session.GetString(TOKEN_SESSION_KEY) : throw new UnauthorizedAccessException();
        }
        public User GetUser()
        {
            if (IsAuthenticated())
            {
                return new User()
                {
                    Name = _httpContextAccessor.HttpContext.Session.GetString(USERNAME_SESSION_KEY),
                    Email = _httpContextAccessor.HttpContext.Session.GetString(EMAIL_SESSION_KEY),
                    Token = GetToken()
                };
            }
            throw new UnauthorizedAccessException();
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.Session.Keys.Any(x => x == TOKEN_SESSION_KEY);
        }

        public bool SetSessionUserVariables(User user)
        {
            _httpContextAccessor.HttpContext.Session.SetString(TOKEN_SESSION_KEY, user.Token);
            _httpContextAccessor.HttpContext.Session.SetString(EMAIL_SESSION_KEY, user.Email);
            _httpContextAccessor.HttpContext.Session.SetString(USERNAME_SESSION_KEY, user.Name);
            return true;
        }
    }
}
