using System;
namespace ConsumerWebAppDanrevi.Services
{
    public interface ITokenAuth
    {
        bool IsAuthenticated();
        string GetToken();
    }
}
