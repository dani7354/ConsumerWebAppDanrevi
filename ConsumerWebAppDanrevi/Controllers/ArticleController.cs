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
        private readonly IArticleApiProxy _articlesApiProxy;
        private readonly ITagApiProxy _tagApiProxy;

        public ArticleController(IArticleApiProxy _articleApiProxy, ITagApiProxy tagApiProxy)
        {
            _articlesApiProxy = _articleApiProxy;
            this._tagApiProxy = tagApiProxy;
        }
        // GET: Article
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Nyheder";
            ViewBag.Tags = await _tagApiProxy.GetAllTagsAsync<string>();
            var articles = await _articlesApiProxy.AllAsync<ArticleDetailsViewModel>();
            return View(articles.OrderByDescending(a => a.DateCreated));
        }

        // GET: Article/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var article = await _articlesApiProxy.FindAsync<ArticleDetailsViewModel>(id);
            return View(article);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Opret nyhedsartikel";
            return View(new ArticleCreateViewModel());
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] ArticleCreateViewModel article)
        {
            try
            {
               await _articlesApiProxy.CreateAsync<ArticleCreateViewModel>(article, HttpContext.Session.GetString("token"));
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
                var article =  await _articlesApiProxy.FindAsync<ArticleDetailsViewModel>(id);
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
            ViewBag.Title = articleEditModel?.Title;
           
            return View(articleEditModel);
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(int id, [FromForm] ArticleCreateViewModel article)
        {
            try
            {
                await _articlesApiProxy.UpdateAsync(id, article, HttpContext.Session.GetString("token"));
               

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
          await _articlesApiProxy.DeleteAsync(id, HttpContext.Session.GetString("token"));
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> GetByTag([FromQuery]string tag)
        {
            ViewBag.Tags = await _tagApiProxy.GetAllTagsAsync<string>();
            ViewBag.Title = $"#{tag}";
            var articles = await _articlesApiProxy.GetByTagAsync<ArticleDetailsViewModel>(tag);
            return View(nameof(Index), articles.OrderByDescending(a => a.DateCreated));
        }
    }
}