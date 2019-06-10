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
using ConsumerWebAppDanrevi.Services.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerWebAppDanrevi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthApiProxy _apiProxy;
        private readonly ITokenAuth _tokenAuth;

        public AuthController(IAuthApiProxy apiProxy, ITokenAuth tokenAuth)
        {
           _apiProxy= apiProxy;
            _tokenAuth = tokenAuth;
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
                _tokenAuth.SetSessionUserVariables(user);


            }
            catch(HttpRequestException ex)
            {
                ViewBag.Ex = ex.Message;
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
            _tokenAuth.ClearSession();
            return RedirectToAction(nameof(Login));

        }
    }
}
