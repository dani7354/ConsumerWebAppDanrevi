using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ApiProxy.Contracts;
using Models.Course;
using Microsoft.AspNetCore.Mvc;
using ConsumerWebAppDanrevi.Services.Contracts;

namespace ConsumerWebAppDanrevi.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseApiProxy _apiProxy;
        private readonly ITokenAuth _tokenAuth;

        public CourseController(ICourseApiProxy apiProxy, ITokenAuth tokenAuth)
        {
            _apiProxy = apiProxy;
            _tokenAuth = tokenAuth;
        }
        // GET: Course
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Alle kurser";
            try
            {
                var courses = await _apiProxy.AllAsync<CourseDetailsViewModel>();
                return View(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        // GET: Course/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var course = await _apiProxy.FindWithParticipantsAsync<CourseDetailsViewModel>(id,_tokenAuth.GetToken());
                ViewBag.Title = course.Name;
                return View(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
                await _apiProxy.CreateAsync(course, _tokenAuth.GetToken());
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: Course/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Title = "Ændr kursus";
            var course = await _apiProxy.FindAsync<CourseCreateViewModel>(id);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromRoute]int id,[FromForm] CourseCreateViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            try
            {
                await _apiProxy.UpdateAsync(id, course, _tokenAuth.GetToken());

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: Course/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _apiProxy.DeleteAsync(id, _tokenAuth.GetToken());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteParticipant([FromQuery] int courseId, [FromQuery] string email)
        {
            try
            {
                await _apiProxy.DeleteParticipantAsync(courseId, email, _tokenAuth.GetToken());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return RedirectToAction(nameof(Details), new { id = courseId });

        }
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddParticipant([FromQuery] int courseId, [FromForm] string email)
        {
            try
            {
                await _apiProxy.AddParticipantAsync(courseId, email, _tokenAuth.GetToken());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
         
            return RedirectToAction(nameof(Details), new { id = courseId });

        }
    }
}