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
    public class VASController : Controller
    {

        private readonly IVASApiClient _vasApiClient;
        private readonly IConfiguration _configuration;


        public VASController(IVASApiClient vasApiClient, IConfiguration configuration)
        {
            _vasApiClient = vasApiClient;
            _configuration = configuration;
        }

        // GET: ProvidersController
        public async Task<ActionResult> Index()
        {
            var session = HttpContext.Session.GetString("Token");
            var request = await _vasApiClient.GetAll(session);
            return View(request);
        }

        // GET: ProvidersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _vasApiClient.Details(id);
            return View(result);
        }

        // GET: ProvidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvidersController/Create
        [HttpPost]
        public async Task<IActionResult> Create(VAS request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _vasApiClient.Create(request);
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
            var result = await _vasApiClient.Details(id);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(VAS request)
        {
            var result = await _vasApiClient.Edit(request.Id, request);
            return RedirectToAction("Index", "VAS");
        }

        // POST: ProvidersController/Edit/5
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            if (!ModelState.IsValid)
                return View();

            var result = await _vasApiClient.Delete(id);
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
