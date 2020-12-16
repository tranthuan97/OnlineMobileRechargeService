using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineMobileRechargeService.Admin.Services;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Controllers
{
    [Authorize]
    public class ProvidersController : Controller
    {

        private readonly IProviderApiClient _providerApiClient;
        private readonly IConfiguration _configuration;


        public ProvidersController(IProviderApiClient providerApiClient, IConfiguration configuration)
        {
            _providerApiClient = providerApiClient;
            _configuration = configuration;
        }

        // GET: ProvidersController
        public async Task<ActionResult> Index()
        {
            var session = HttpContext.Session.GetString("Token");
            var request = await _providerApiClient.GetAll(session);
            return View(request);
        }

        // GET: ProvidersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _providerApiClient.Details(id);
            return View(result);
        }

        // GET: ProvidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvidersController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Provider request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _providerApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Successful";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong !");
            return View(request);
        }

        // GET: ProvidersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _providerApiClient.Details(id);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Provider request)
        {
            var result = await _providerApiClient.Edit(request.Id, request);
            return RedirectToAction("Index", "Providers");
        }

        // POST: ProvidersController/Edit/5
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            if (!ModelState.IsValid)
                return View();

            var result = await _providerApiClient.Delete(id);
            if (result)
            {
                TempData["result"] = "Successful";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong !");
            return RedirectToAction("Index","Providers");
        }
    }
}
