using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Models.Course;
using Newtonsoft.Json;

namespace ApiProxy
{
    public class CourseRestProxy : ICourseApiProxy
    {
        private readonly string _baseEndpoint = "http://localhost:8000/api/courses";
        public IList<T> All<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<T>> AllAsync<T>() where T : CourseBase
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(_baseEndpoint);
            var courses = JsonConvert.DeserializeObject<List<T>>(json);
            return courses;
        }

        public void Create<T>(T article)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync<T>(T course) where T : CourseBase
        {
            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(course);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_baseEndpoint, stringContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
        }

        public T Find<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindAsync<T>(int id) where T : CourseBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var course = JsonConvert.DeserializeObject<T>(json);
            return course;
        }

        public async Task<T> FindWithParticipantsAsync<T>(int id) where T : CourseBase
        {
            var url = $"{_baseEndpoint}/{id}/participants";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var course = JsonConvert.DeserializeObject<T>(json);
            return course;
        }

        public async Task UpdateAsync<T>(int id, T course) where T : CourseBase
        {
            var url = $"{_baseEndpoint}/{id}";
            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(course);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
        }
    }
}
