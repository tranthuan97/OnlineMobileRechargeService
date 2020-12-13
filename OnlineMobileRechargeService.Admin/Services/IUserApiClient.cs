using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Admin.Services
{
    public interface IUserApiClient
    {
        public Task<string> Authenticate(LoginRequest request);
        public Task<List<AppUser>> GetAllUsers(string sessions);
    }
}
