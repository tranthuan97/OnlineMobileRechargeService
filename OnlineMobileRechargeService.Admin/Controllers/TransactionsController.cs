using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineMobileRechargeService.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionApiClient _transactionApiClient;
        private readonly IConfiguration _configuration;


        public TransactionsController(ITransactionApiClient transactionApiClient, IConfiguration configuration)
        {
            _transactionApiClient = transactionApiClient;
            _configuration = configuration;
        }

        // GET: TransactionsController
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var session = HttpContext.Session.GetString("Token");
            Console.WriteLine("get duoc token: ", session);
            var request = await _transactionApiClient.GetAll(session);

            return View(request);
        }

        // GET: TransactionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionsController/Create
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

        // GET: TransactionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionsController/Edit/5
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

        // GET: TransactionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionsController/Delete/5
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
