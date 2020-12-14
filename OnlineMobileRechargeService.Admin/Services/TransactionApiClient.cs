using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Services
{
    public class TransactionApiClient : ITransactionApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TransactionApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<List<Transaction>> GetAll(string sessions)
        {
            var client = _httpClientFactory.CreateClient();
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + sessions);
            var response = await client.GetAsync("api/Transactions/getall");
            var body = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<Transaction>>(body);

            //var users = JsonConvert.DeserializeObject<List<Transaction>>(body);
            return users;
        }
    }
}
