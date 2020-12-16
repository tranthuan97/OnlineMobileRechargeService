using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Services
{
    public interface IProviderApiClient
    {
        public Task<List<Provider>> GetAll(string sessions);
        public Task<bool> Create(Provider request);
        public Task<bool> Delete(int id);
        public Task<Provider> Details(int id);
        public Task<bool> Edit(int id, Provider provider);
    }
}
