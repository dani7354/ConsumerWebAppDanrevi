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
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Nyheder";
            var articles = await _ApiProxy.AllAsync<ArticleDetailsViewModel>();
            return View(articles);
        }

        // GET: Article/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var article = await _ApiProxy.FindAsync<ArticleDetailsViewModel>(id);
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
        public async Task<ActionResult> Create([FromForm] ArticleCreateViewModel article)
        {
            try
            {
               await _ApiProxy.CreateAsync<ArticleCreateViewModel>(article);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ArticleCreateViewModel articleEditModel = null;
            try
            {
                var article =  await _ApiProxy.FindAsync<ArticleDetailsViewModel>(id);
                articleEditModel = new ArticleCreateViewModel()
                {
                    Content = article.Content,
                    Title = article.Title,
                    Tags = "#" + string.Join('#', article.Tags)
                };
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
            
           
            return View(articleEditModel);
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(int id, [FromForm] ArticleCreateViewModel article)
        {
            try
            {
                await _ApiProxy.UpdateAsync<ArticleCreateViewModel>(id, article);
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public async  Task<ActionResult> Delete(int id)
        {
          await _ApiProxy.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> GetByTag([FromQuery]string tag)
        {
            ViewBag.Title = $"#{tag}";
            var articles = await _ApiProxy.GetByTagAsync<ArticleDetailsViewModel>(tag);
            return View(nameof(Index), articles);
        }
    }
}