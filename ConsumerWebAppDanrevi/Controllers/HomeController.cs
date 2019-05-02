using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsumerWebAppDanrevi.Models;
using ApiProxy;
using ApiProxy.Contracts;
using Models.Article;

namespace ConsumerWebAppDanrevi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleApiProxy _apiProxy;

        public HomeController(IArticleApiProxy _apiProxy)
        {
            this._apiProxy = _apiProxy;
        }
        public IActionResult Index()
        {
           var result =  _apiProxy.All<ArticleDetailsViewModel>();
            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
