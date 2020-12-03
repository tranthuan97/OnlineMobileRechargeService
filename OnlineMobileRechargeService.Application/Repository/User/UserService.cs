using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineMobileRechargeService.Application.Helpers;
using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.Repository.User
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        public UserService()
        {
        }

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            using (var dbContext = new OMRSDbContext())
            {
                AppUser user = await dbContext.AppUsers.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Role", user.Role),
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //if (user.Token == "")
                //{
                //    user.Token = tokenHandler.WriteToken(token);

                //}
                user.Token = tokenHandler.WriteToken(token);
                return user.Token;
            }
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            using (var dbContext = new OMRSDbContext())
            {
                
                return await dbContext.AppUsers.ToListAsync();
            }

        }

        public async Task<AppUser> GetById(int id)
        {
            using (var dbContext = new OMRSDbContext())
            {
                var user = await dbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
                return user.WithoutPassword();
            }
        }

        public async Task<AppUser> Register(RegisterRequest request, string role)
        {
            using (var dbContext = new OMRSDbContext())
            {
                if (request.Password.Equals(request.ConfirmPassword))
                {
                    var u = dbContext.AppUsers.FirstOrDefault(x => x.Username == request.UserName && x.Role == "Admin");
                    if (u != null)
                    {
                        return null;
                    }
                    var user = new AppUser()
                    {
                        Username = request.UserName,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Password = request.Password,
                        Role = role,
                    };
                    Console.WriteLine(user);
                    dbContext.AppUsers.Add(user);
                    await dbContext.SaveChangesAsync();
                    return user;
                }
                return null;
            }
        }

        public async Task<bool> DeleteUserById(int id)
        {
            using (var dbContext = new OMRSDbContext())
            {
                var appUser = await dbContext.AppUsers.FindAsync(id);
                if (appUser == null)
                {
                    return false;
                }

                dbContext.AppUsers.Remove(appUser);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }

        public async Task<AppUser> UpdateById(AppUser user)
        {

            //loi cmnr @@
            using (var dbContext = new OMRSDbContext())
            {
                var appUser = dbContext.AppUsers.AsNoTracking().Where(t => t.Id == user.Id).FirstOrDefault();
                if (appUser == null)
                {
                    return null;
                }

                appUser = user;

                dbContext.Update(appUser);

                await dbContext.SaveChangesAsync();

                return user;
            }
        }
    }
}
