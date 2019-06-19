using System;
using ApiProxy.Contracts;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiProxy
{
    public class TagRestProxy : RestProxyBase, ITagApiProxy
    {

        public TagRestProxy(string endPoint) : base(endPoint)
        { }
        public async Task<IList<T>>GetAllTagsAsync<T>()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(_baseEndpoint);
                var tags = JsonConvert.DeserializeObject<List<T>>(json);
                return tags;
            }     
        }
    }
}
