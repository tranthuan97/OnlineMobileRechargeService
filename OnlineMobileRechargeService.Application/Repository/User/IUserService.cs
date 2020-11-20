using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.Repository.User
{
    public interface IUserService
    {
        AppUser Authenticate(string username, string password);
        IEnumerable<AppUser> GetAll();
        AppUser GetById(int id);

        Task<bool> Register(RegisterRequest request);
    }
}
