using System;
using System.Net.Http;

namespace ApiProxy
{
    public abstract class RestProxyBase
    {
       

        
        protected HttpClient SetupHttpClient(string token = null)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            if (token != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            return httpClient;
        }
    }
}
