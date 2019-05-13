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
    public class ArticleRestProxy : IArticleApiProxy
    {
        private readonly string _baseEndpoint;
        public ArticleRestProxy(string baseEndpoint)
        {
            _baseEndpoint = baseEndpoint;
        }

        public IList<T> All<T>() where T : ArticleBase
        {
            var httpClient = new HttpClient();
            var json = httpClient.GetStringAsync(_baseEndpoint).Result;
            var articles = JsonConvert.DeserializeObject<List<T>>(json);
            return articles;
        }

        public async Task<IList<T>> AllAsync<T>() where T : ArticleBase
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(_baseEndpoint);
            var articles = JsonConvert.DeserializeObject<List<T>>(json);
            return articles;

        }

        public void Create<T>(T article) where T : ArticleBase
        {
            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(article);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(_baseEndpoint, stringContent);
           


        }

        public async  Task CreateAsync<T>(T article, string apiToken) where T : ArticleBase
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            string json = JsonConvert.SerializeObject(article);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_baseEndpoint, stringContent);
            response.EnsureSuccessStatusCode();
        }

        public void Delete(int id)
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync(url);
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.Result.StatusCode.ToString());
            }
        }

        public async Task DeleteAsync(int id, string apiToken)
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        public T Find<T>(int id) where T : ArticleBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            var json = httpClient.GetStringAsync(url).Result;
            var article = JsonConvert.DeserializeObject<T>(json);
            return article;

        }

        public async Task<T> FindAsync<T>(int id) where T : ArticleBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var article = JsonConvert.DeserializeObject<T>(json);
            return article;

        }

        public IList<T> GetByTag<T>(string tag)
        {
            var url = $"{_baseEndpoint}/tag/{tag}";
            var httpClient = new HttpClient();
            var json = httpClient.GetStringAsync(url).Result;
            var articles = JsonConvert.DeserializeObject<List<T>>(json);
            return articles;
        }

        public async Task<IList<T>> GetByTagAsync<T>(string tag)
        {
            var url = $"{_baseEndpoint}/tag/{tag}";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var articles = JsonConvert.DeserializeObject<List<T>>(json);
            return articles;
        }

        public void Update<T>(int id, T article) where T : ArticleBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(article);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync(url, stringContent);
        }

        public async Task UpdateAsync<T>(int id, T article, string apiToken) where T : ArticleBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            string json = JsonConvert.SerializeObject(article);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            response.EnsureSuccessStatusCode();

        }

       
    }
}
