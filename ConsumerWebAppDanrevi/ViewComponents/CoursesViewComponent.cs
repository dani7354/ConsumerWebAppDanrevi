using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using Models.Course;

namespace ConsumerWebAppDanrevi.ViewComponents
{
    public class CoursesViewComponent : ViewComponent
    {
        readonly ICourseApiProxy _apiProxy;
        public CoursesViewComponent(ICourseApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }
        public IViewComponentResult Invoke(int records=5)
        {
            var courses = _apiProxy.AllAsync<CourseDetailsViewModel>().Result;
            return View(courses.OrderBy(c => c.Start).Take(records).Where(c => c.Start > DateTime.Now));
        }
    }
}
