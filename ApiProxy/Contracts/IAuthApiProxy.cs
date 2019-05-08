using System;
using System.Threading.Tasks;
using Models.Login;

namespace ApiProxy.Contracts
{
    public interface IAuthApiProxy
    {
       
        Task<User> LoginAsync<T>(T userCredentials);
    }
}
