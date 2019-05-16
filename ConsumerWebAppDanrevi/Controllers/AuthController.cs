using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ApiProxy.Contracts;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerWebAppDanrevi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthApiProxy _apiProxy;
        public AuthController(IAuthApiProxy apiProxy)
        {
           _apiProxy= apiProxy;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([FromForm] LoginViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return View(credentials);
            }
            try
            {
                var user = await _apiProxy.LoginAsync(credentials);
                HttpContext.Session.SetString("token", user.Token);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("name", user.Name);

            }
            catch(HttpRequestException ex)
            {
                ViewBag.Ex = ex.StackTrace;
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Fejl: " + ex.Message);
            }

            return RedirectToAction("Index", "Home", null);
        }
        [HttpGet]
        public  ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));

        }
    }
}
