﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsumerWebAppDanrevi.Models;
using ApiProxy;
using ApiProxy.Contracts;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Models.Article;

namespace ConsumerWebAppDanrevi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.Session.GetString("name");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
