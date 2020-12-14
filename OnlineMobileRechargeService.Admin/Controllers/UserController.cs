using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using OnlineMobileRechargeService.Admin.Services;
using OnlineMobileRechargeService.Application.Helpers;
using OnlineMobileRechargeService.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;


        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }


        // GET: UsersController
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var session = HttpContext.Session.GetString("Token");
            Console.WriteLine("get duoc token: ", session);
            var request = await _userApiClient.GetAllUsers(session);
            Console.WriteLine(request);


            return View(request);
        }


        public async Task<ActionResult> Login()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login","User");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            Console.WriteLine(request.Password);
            var tokenString = await _userApiClient.Authenticate(request);

            Console.WriteLine(tokenString);

            JObject t = JObject.Parse(tokenString);

            Console.WriteLine(t);

            string token = t.GetValue("data").ToString();

            //var token = (string)t.SelectToken("data");

            Console.WriteLine("token here: " + t.GetValue("data").ToString());

            var userPrincipal = this.validateTokent(t.GetValue("data").ToString());
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(30),
                IsPersistent = false
            };

            HttpContext.Session.SetString("Token", token);

            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    authProperties);

            return RedirectToAction("Index","Home");
        }


        private ClaimsPrincipal validateTokent(string token)
        {

            Console.WriteLine("day la token: ", token);
            IdentityModelEventSource.ShowPII = true;

            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);

            SecurityToken validataToken;
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters();

            //tokenValidationParameters.ValidateLifetime = true;
            tokenValidationParameters.ValidateIssuer = false;
            tokenValidationParameters.ValidateAudience = false;
            tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(key);

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out validataToken);
            return principal;
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
