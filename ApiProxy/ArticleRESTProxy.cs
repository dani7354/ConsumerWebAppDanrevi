﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Domain;
using Newtonsoft.Json;

namespace ApiProxy
{
    public class ArticleRestProxy : IArticleApiProxy
    {
        private string _baseEndpoint = "http://danrevi-api.azurewebsites.net/api/articles";

        public IList<T> All<T>() where T : ArticleBase
        {
            var httpClient = new HttpClient();
            var json = httpClient.GetStringAsync(_baseEndpoint).Result;
            var articles = JsonConvert.DeserializeObject<List<T>>(json);
            return articles;
        }

        public void Create<T>(T article) where T : ArticleBase
        {
           
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : ArticleBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            var json = httpClient.GetStringAsync(url).Result;
            var article = JsonConvert.DeserializeObject<T>(json);
            return article;

        }

        public IList<T> GetByTag<T>(string tag)
        {
            throw new NotImplementedException();
        }

        IList<T> IApiProxy.All<T>()
        {
            throw new NotImplementedException();
        }

        void IApiProxy.Create<T>(T article)
        {
            throw new NotImplementedException();
        }

        T IApiProxy.Find<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
