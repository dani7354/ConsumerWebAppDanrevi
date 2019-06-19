using System;
using ApiProxy.Contracts;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using Models.Login;

namespace ApiProxy
{
    public class AuthRestProxy : RestProxyBase, IAuthApiProxy
    {
        public AuthRestProxy(string baseEndpoint) : base(baseEndpoint) {}
        public async Task<User> LoginAsync<T>(T userCredentials)
        {
            using (var httpClient = base.SetupHttpClient())
            {
                var json = JsonConvert.SerializeObject(userCredentials);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(string.Empty, stringContent);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }   
        }
    }
}
