using System;
using Models.Login;
namespace ConsumerWebAppDanrevi.Services.Contracts
{
    public interface ITokenAuth
    {
        bool IsAuthenticated();
        string GetToken();
        bool SetSessionUserVariables(User user);
        User GetUser();
        void ClearSession();
    }
}
