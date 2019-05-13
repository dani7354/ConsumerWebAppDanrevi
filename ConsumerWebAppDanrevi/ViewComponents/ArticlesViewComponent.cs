using System;
using Microsoft.AspNetCore.Mvc;
using ApiProxy.Contracts;
using System.Threading.Tasks;
using System.Linq;
using Models.Article;
namespace ConsumerWebAppDanrevi.ViewComponents
{
    public class ArticlesViewComponent
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
