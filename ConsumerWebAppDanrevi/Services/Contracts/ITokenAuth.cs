using System;
namespace ConsumerWebAppDanrevi.Services.Contracts
{
    public interface ITokenAuth
    {
        bool IsAuthenticated();
        string GetToken();
    }
}
