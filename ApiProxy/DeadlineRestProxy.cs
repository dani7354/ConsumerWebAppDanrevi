﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using System.Net.Http;
using Newtonsoft.Json;
namespace ApiProxy
{
    public class DeadlineRestProxy : RestProxyBase, IDeadlinesApiProxy
    {
        private readonly string _baseEndpoint;

        public DeadlineRestProxy(string baseEndpoint) 
        {
            this._baseEndpoint = baseEndpoint;
        }
        public async Task<T> FindDeadline<T>(int id)
        {
            var url = $"{_baseEndpoint}/{id}";
            using (var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                var deadline = JsonConvert.DeserializeObject<T>(json);
                return deadline;
            }   
        }
        public async Task<IList<T>> GetAllDeadlinesAsync<T>()
        {
            using (var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(_baseEndpoint);
                var deadlines = JsonConvert.DeserializeObject<List<T>>(json);
                return deadlines;
            } 
        }
    }
}
