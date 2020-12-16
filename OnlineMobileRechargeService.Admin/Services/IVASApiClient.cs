using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Services
{
    public interface IVASApiClient
    {
        public Task<List<VAS>> GetAll(string sessions);
        public Task<bool> Create(VAS request);
        public Task<bool> Delete(int id);
        public Task<VAS> Details(int id);
        public Task<bool> Edit(int id, VAS vas);
    }
}
