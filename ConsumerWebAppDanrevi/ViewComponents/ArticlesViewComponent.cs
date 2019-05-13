using System;
using Microsoft.AspNetCore.Mvc;
using ApiProxy.Contracts;
using System.Threading.Tasks;
using System.Linq;
using Models.Course;

namespace ConsumerWebAppDanrevi.ViewComponents
{
    public class ArticlesViewComponent : ViewComponent
    {
        public ArticlesViewComponent()
        {

        }
        public async Task<IViewComponentResult> Invoke([FromServices] ICourseApiProxy apiProxy, int records=5)
        {
            var courses = await apiProxy.AllAsync<CourseDetailsViewModel>();
            return View(courses.OrderBy(c => c.Start).Take(records));
        }
    }
}
