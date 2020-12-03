using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public static Object DecodeToken(this string token)
        {
            if (token == null)
            {
                return "";
            }
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
            Dictionary<string, Object> user = new Dictionary<string, object>();

            var role = tokenS.Claims.First(claim => claim.Type == "role").Value;
            var id = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            var exp = tokenS.Claims.First(claim => claim.Type == "exp").Value;
            return new { role, id, exp };
        }
    }
}
