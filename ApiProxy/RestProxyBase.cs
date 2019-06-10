using System;
using System.Net.Http;

namespace ApiProxy
{
    internal abstract class RestProxyBase
    {
        private readonly string baseEndpoint;
       

        protected RestProxyBase(string baseEndpoint, string token)
        {
            this.baseEndpoint = baseEndpoint;
        }
        public HttpClient SetupHttpClient()
        {
            return null;
        }
    }
}
