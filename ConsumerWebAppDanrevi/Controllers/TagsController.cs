using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiProxy.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerWebAppDanrevi.Controllers
{
    public class TagsController : ControllerBase
    {
        private readonly ITagApiProxy _apiProxy;
        public TagsController(ITagApiProxy apiProxy)
        {
            this._apiProxy = apiProxy;
        }
        // GET: /<controller>/
        public IActionResult GetTagsBySearchText([FromQuery]string text)
        {
            var tags = _apiProxy.GetAllTagsAsync<string>().Result;

            var matches = tags.Where(t => t.Contains(text.ToLower()));
            return Ok(matches);
          
        }
    }
}
