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

        public static string CreateMD5(this string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
