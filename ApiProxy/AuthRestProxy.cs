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
        private readonly string _baseEndpoint;

        public AuthRestProxy(string baseEndpoint)
        {
            this._baseEndpoint = baseEndpoint;
        }
        public async Task<User> LoginAsync<T>(T userCredentials)
        {
            var url = $"{_baseEndpoint}";
            HttpClient httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(userCredentials);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
         
            return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
        }
    }
}
