using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Article;
using ConsumerWebAppDanrevi.Services.Contracts;

namespace ConsumerWebAppDanrevi.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleApiProxy _articlesApiProxy;
        private readonly ITagApiProxy _tagApiProxy;
        private readonly ITokenAuth _tokenAuth;

        public ArticleController(IArticleApiProxy _articleApiProxy, ITagApiProxy tagApiProxy, ITokenAuth tokenAuth)
        {
            _articlesApiProxy = _articleApiProxy;
            _tagApiProxy = tagApiProxy;
            this._tokenAuth = tokenAuth;
        }
        // GET: Article
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Nyheder";
            try
            {
                ViewBag.Tags = await _tagApiProxy.GetAllTagsAsync<string>();
                var articles = await _articlesApiProxy.AllAsync<ArticleDetailsViewModel>();
                return View(articles.OrderByDescending(a => a.DateCreated));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

        // GET: Article/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var article = await _articlesApiProxy.FindAsync<ArticleDetailsViewModel>(id);
                return View(article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
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
               await _articlesApiProxy.CreateAsync<ArticleCreateViewModel>(article, _tokenAuth.GetToken());
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View(article);
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
                await _articlesApiProxy.UpdateAsync(id, article, _tokenAuth.GetToken());
               

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View(article);
            }
        }

        // GET: Article/Delete/5
        public async  Task<ActionResult> Delete(int id)
        {
            try
            {
                await _articlesApiProxy.DeleteAsync(id, _tokenAuth.GetToken());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> GetByTag([FromQuery]string tag)
        {
            ViewBag.Tags = await _tagApiProxy.GetAllTagsAsync<string>();
            ViewBag.Title = $"#{tag}";
            try
            {
                var articles = await _articlesApiProxy.GetByTagAsync<ArticleDetailsViewModel>(tag);
                return View(nameof(Index), articles.OrderByDescending(a => a.DateCreated));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
           
        }
    }
}