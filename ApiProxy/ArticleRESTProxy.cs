using System;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Find<T>(int id) where T : ArticleBase
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
