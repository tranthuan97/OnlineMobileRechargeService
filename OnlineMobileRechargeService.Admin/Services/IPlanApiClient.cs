using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Services
{
    public interface IPlanApiClient
    {
        public Task<List<Plan>> GetAll(string sessions);
        public Task<bool> Create(Plan request);
        public Task<bool> Delete(int id);
        public Task<Plan> Details(int id);
        public Task<bool> Edit(int id, Plan plan);
    }
}
