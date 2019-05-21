using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Models.Deadline;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerWebAppDanrevi.Controllers
{
    public class DeadlineController : Controller
    {
        private readonly IDeadlinesApiProxy _apiProxy;

        public DeadlineController(IDeadlinesApiProxy apiProxy)
        {
            this._apiProxy = apiProxy;
        }

        public async Task<IActionResult> Details(int id)
        {
            var deadline = await _apiProxy.FindDeadline<DeadlineDetailsViewModel>(id);
            return View(deadline);
        }
   
    
    }
}
