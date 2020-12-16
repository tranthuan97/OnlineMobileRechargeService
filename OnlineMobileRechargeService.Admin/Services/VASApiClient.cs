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
    public class VASApiClient : IVASApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VASApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<bool> Create(VAS request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/VAS/", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            Console.WriteLine(id);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.DeleteAsync($"/api/VAS/{id}");
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<VAS> Details(int id)
        {
            Console.WriteLine(id);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync($"/api/VAS/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var objResponse = JsonConvert.DeserializeObject<VAS>(body);

            //var users = JsonConvert.DeserializeObject<AppUser>(body);
            return objResponse;
        }

        public async Task<bool> Edit(int id, VAS vas)
        {
            var json = JsonConvert.SerializeObject(vas);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PutAsync($"/api/VAS/{id}", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<List<VAS>> GetAll(string sessions)
        {
            var client = _httpClientFactory.CreateClient();
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + sessions);
            var response = await client.GetAsync("api/VAS/");
            var body = await response.Content.ReadAsStringAsync();

            //var users = JsonConvert.DeserializeObject<List<Transaction>>(body);

            var objResponse =
    JsonConvert.DeserializeObject<List<VAS>>(body);

            //var users = JsonConvert.DeserializeObject<List<Transaction>>(body);
            return objResponse;
        }
    }
}
