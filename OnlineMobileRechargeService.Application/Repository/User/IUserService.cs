﻿using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.Repository.User
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetById(int id);

        Task<bool> DeleteUserById(int id);
        Task<AppUser> UpdateById(int id, AppUser user);
        Task<string> ChangePassword(int id, ChangePassword user);

        Task<AppUser> Register(RegisterRequest request, string role);
    }
}
