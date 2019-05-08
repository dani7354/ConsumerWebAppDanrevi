using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ApiProxy.Contracts;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerWebAppDanrevi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthApiProxy _apiProxy;
        public LoginController(IAuthApiProxy apiProxy)
        {
           _apiProxy= apiProxy;
        }

       

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        // POST
        public async Task<ActionResult> Login([FromForm] LoginViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", credentials);
            }
            try
            {
                var user = await _apiProxy.LoginAsync<LoginViewModel>(credentials);
                HttpContext.Session.SetString("token", user.Token);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("name", user.Name);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return RedirectToAction(nameof(Index), nameof(HomeController), null);
        }
    }
}
