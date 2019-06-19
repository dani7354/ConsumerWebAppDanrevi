using System;
using ApiProxy.Contracts;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using Models.Login;

namespace ApiProxy
{
    public class AuthRestProxy : IAuthApiProxy
    {
        private readonly string baseEndpoint;

        public AuthRestProxy(string baseEndpoint) {
            this.baseEndpoint = baseEndpoint;
        }
        public async Task<User> LoginAsync<T>(T userCredentials)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userCredentials);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(baseEndpoint, stringContent);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }   
        }
    }
}
