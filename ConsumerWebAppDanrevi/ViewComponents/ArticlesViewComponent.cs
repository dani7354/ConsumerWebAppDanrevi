using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Contracts;

using Models.Article;
namespace ConsumerWebAppDanrevi.ViewComponents
{
    public class ArticlesViewComponent : ViewComponent
    {
        private readonly IArticleApiProxy _apiProxy;

        public ArticlesViewComponent(IArticleApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }
        public IViewComponentResult Invoke()
        {
            var articles = _apiProxy.AllAsync<ArticleDetailsViewModel>().Result;
            return View(articles.OrderBy(a => a.DateCreated));
        }
    }
}
