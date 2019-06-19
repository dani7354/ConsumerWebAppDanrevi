using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Models.Article;
using Newtonsoft.Json;

namespace ApiProxy
{
    public class ArticleRestProxy : RestProxyBase, IArticleApiProxy
    {

        public ArticleRestProxy(string baseEndpoint) : base(baseEndpoint)
        {}

        public async Task<IList<T>> AllAsync<T>() where T : ArticleBase
        {
            using(var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Empty);
                var articles = JsonConvert.DeserializeObject<List<T>>(json);
                return articles;
            }
        }

        public async Task CreateAsync<T>(T article, string apiToken) where T : ArticleBase
        {
            using(var httpClient = base.SetupHttpClient(apiToken))
            {
                string json = JsonConvert.SerializeObject(article);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(string.Empty, stringContent);
                response.EnsureSuccessStatusCode();
            }  
        }

        public async Task DeleteAsync(int id, string apiToken)
        {
      
            var url = $"{id}";
            using (var httpClient = base.SetupHttpClient(apiToken))
            {
                var response = await httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<T> FindAsync<T>(int id) where T : ArticleBase
        {

            var url = $"{id}";
            using (var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                var article = JsonConvert.DeserializeObject<T>(json);
                return article;
            }
        }

        public async Task<IList<T>> GetByTagAsync<T>(string tag)
        {
            var url = $"tag/{tag}";
            using (var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                var articles = JsonConvert.DeserializeObject<List<T>>(json);
                return articles;
            }
            
        }

        public async Task UpdateAsync<T>(int id, T article, string apiToken) where T : ArticleBase
        {
            var url = $"{id}";
            using (var httpClient = base.SetupHttpClient(apiToken))
            {
                string json = JsonConvert.SerializeObject(article);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, stringContent);
                response.EnsureSuccessStatusCode();
            }
        }

       
    }
}
