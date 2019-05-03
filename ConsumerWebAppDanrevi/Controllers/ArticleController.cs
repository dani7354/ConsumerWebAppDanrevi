using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Article;

namespace ConsumerWebAppDanrevi.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleApiProxy _ApiProxy;
        public ArticleController(IArticleApiProxy _apiProxy)
        {
            _ApiProxy = _apiProxy;
        }
        // GET: Article
        public ActionResult Index()
        {
            var articles = _ApiProxy.All<ArticleDetailsViewModel>();
            return View(articles);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            var article = _ApiProxy.Find<ArticleDetailsViewModel>(id);
            return View(article);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View(new ArticleCreateViewModel());
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ArticleCreateViewModel article)
        {
            try
            {
              
                _ApiProxy.Create<ArticleCreateViewModel>(article);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var article = _ApiProxy.Find<ArticleDetailsViewModel>(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
            
           
            return View();
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            _ApiProxy.Delete(id);
            return RedirectToAction(nameof(Index));
        }

      

        public ActionResult GetByTag([FromQuery]string tag)
        {
            var articles = _ApiProxy.GetByTag<ArticleDetailsViewModel>(tag);
            return View(nameof(Index), articles);
        }
    }
}