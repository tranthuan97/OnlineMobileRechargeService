﻿using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMobileRechargeService.Application.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<AppUser> WithoutPasswords(this IEnumerable<AppUser> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static AppUser WithoutPassword(this AppUser user)
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }
    }
}
