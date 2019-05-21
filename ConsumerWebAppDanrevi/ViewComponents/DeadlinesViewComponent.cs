using System;
using ApiProxy.Contracts;
using System.Linq;
using Models.Deadline;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerWebAppDanrevi.ViewComponents
{
    public class DeadlinesViewComponent : ViewComponent
    {
        private readonly IDeadlinesApiProxy _apiProxy;

        public DeadlinesViewComponent(IDeadlinesApiProxy apiProxy)
        {
            this._apiProxy = apiProxy;
        }
        public IViewComponentResult Invoke(int records = 5)
        {
            var deadlines = _apiProxy.GetAllDeadlinesAsync<DeadlineDetailsViewModel>().Result;
            return View(deadlines.OrderBy(d => d.Date).Take(records));
        }
    }
}
