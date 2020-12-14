using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Services
{
    public interface ITransactionApiClient
    {
        public Task<List<Transaction>> GetAll(string sessions);
    }
}
