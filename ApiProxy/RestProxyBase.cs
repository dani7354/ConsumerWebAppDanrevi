﻿using System;
using System.Net.Http;

namespace ApiProxy
{
    public abstract class RestProxyBase
    {
        protected readonly string _baseEndpoint;

        protected RestProxyBase(string baseEndpoint)
        {
            this._baseEndpoint = baseEndpoint;
        }
        protected HttpClient SetupHttpClient(string token = null)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{_baseEndpoint}/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            if (token != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            return httpClient;
        }
    }
}
