using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ApiProxy.Contracts;
using Models.Course;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerWebAppDanrevi.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseApiProxy _apiProxy;
        public CourseController(ICourseApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }
        // GET: Course
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Alle kurser";
            var courses = await _apiProxy.AllAsync<CourseDetailsViewModel>();
            return View(courses);
        }

        // GET: Course/Details/5
        public async Task<ActionResult> Details(int id)
        {
         
            var course = await _apiProxy.FindWithParticipantsAsync<CourseDetailsViewModel>(id);
            ViewBag.Title = course.Name;
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Opret nyt kursus";
            return View(new CourseCreateViewModel());
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CourseCreateViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            try
            {
                await _apiProxy.CreateAsync(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var course = await _apiProxy.FindAsync<CourseCreateViewModel>(id);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,[FromForm] CourseCreateViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            try
            {
                await _apiProxy.UpdateAsync(id, course);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _apiProxy.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteParticipant([FromQuery] int courseId, [FromQuery] string email)
        {
           await  _apiProxy.DeleteParticipantAsync(courseId, email);

            return RedirectToAction(nameof(Details), new { id = courseId });

        }
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddParticipant([FromQuery] int courseId, [FromForm] string email)
        {
            await _apiProxy.AddParticipantAsync(courseId, email);
            return RedirectToAction(nameof(Details), new { id = courseId });

        }
    }
}