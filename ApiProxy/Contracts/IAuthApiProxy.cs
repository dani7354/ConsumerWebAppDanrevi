using System;
namespace ApiProxy.Contracts
{
    public interface IAuthApiProxy
    {
        string GetToken(string email, string password);
    }
}
