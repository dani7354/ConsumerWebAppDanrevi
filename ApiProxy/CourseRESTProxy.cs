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
    public class CourseRestProxy : RestProxyBase,  ICourseApiProxy
    {
        private readonly string _baseEndpoint;

        public CourseRestProxy(string baseEndpoint) 
        {
            this._baseEndpoint = baseEndpoint;
        }
        public async Task AddParticipantAsync(int courseId, string participantEmail, string apiToken)
        {
            var url = $"{_baseEndpoint}/{courseId}/participants";
            using (var httpClient = base.SetupHttpClient(apiToken))
            {
                var json = "{\"email\":\"" + participantEmail + "\"}";
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, stringContent);
                response.EnsureSuccessStatusCode();
            }
        }
        public async Task<IList<T>> AllAsync<T>() where T : CourseBase
        {
            using(var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(_baseEndpoint);
                var courses = JsonConvert.DeserializeObject<List<T>>(json);
                return courses;
            }
        }

        public async Task CreateAsync<T>(T course, string apiToken) where T : CourseBase
        {
            using (var httpClient = base.SetupHttpClient(apiToken))
            {
                string json = JsonConvert.SerializeObject(course);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(_baseEndpoint, stringContent);
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

        public async Task DeleteParticipantAsync(int courseId, string participantEmail, string apiToken)
        {
            var url = $"{_baseEndpoint}/{courseId}/participants?email={participantEmail}";
            using (var httpClient = base.SetupHttpClient(apiToken))
            {        
                var response = await httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }    
        }

        public async Task<T> FindAsync<T>(int id) where T : CourseBase
        {
            var url = $"{_baseEndpoint}/{id}";
            using (var httpClient = base.SetupHttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                var course = JsonConvert.DeserializeObject<T>(json);
                return course;
            }
        }
        public async Task<T> FindWithParticipantsAsync<T>(int id, string apiToken) where T : CourseBase
        {
            var url = $"{_baseEndpoint}/{id}/participants";
            using (var httpClient = base.SetupHttpClient(apiToken))
            {
                var json = await httpClient.GetStringAsync(url);
                var course = JsonConvert.DeserializeObject<T>(json);
                return course;
            } 
        }
        public async Task UpdateAsync<T>(int id, T course, string apiToken) where T : CourseBase
        {
            var url = $"{_baseEndpoint}/{id}";
            using (var httpClient = base.SetupHttpClient(apiToken))
            {
                string json = JsonConvert.SerializeObject(course);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, stringContent);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
