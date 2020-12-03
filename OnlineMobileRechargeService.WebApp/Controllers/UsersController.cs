using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnlineMobileRechargeService.Application.Repository.User;
using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Application.Helpers;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using OnlineMobileRechargeService.Data.EF;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly OMRSDbContext _dbContext;

        public UsersController(IUserService userService, OMRSDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }


        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");

            data.Add("data", null);
            var userToken = await _userService.Authenticate(request.Username, request.Password);
            if (userToken == null)
            {
                //return BadRequest(new { message = "Username or password is incorrect" });
                data.Remove("status");
                data.TryAdd("status", "WARNING");
                data.Add("message", "Tài khoản hoặc mật khẩu không đúng !");
                return Ok(data);
            }
            data.Remove("data");
            data.Add("data", userToken);
            var uTokenObject = userToken.DecodeToken();
            Console.WriteLine(uTokenObject);
            var nameOfProperty = "id";
            var propertyInfo = uTokenObject.GetType().GetProperty(nameOfProperty);
            var value = propertyInfo.GetValue(uTokenObject, null);
            var roleClaim = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role, StringComparison.InvariantCultureIgnoreCase));
            //User.Claims
            if (roleClaim != null)
            {
                Console.WriteLine(roleClaim);
                Console.WriteLine(roleClaim.Value);
                string role = roleClaim.Value;
                AppUser user = await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.Role == role);
                if (user != null)
                {
                    Console.WriteLine("User is exist !");
                }
            }
            Console.WriteLine(value);
            return Ok(data);
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);
            var user = await _userService.Register(request, "User");
            if (user == null)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Username is exist !");

                return Ok(data);
            }
            data.Remove("data");
            data.Add("data", user);

            return Ok(data);
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest request)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);
            var user = await _userService.Register(request, "Admin");
            if (user == null)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Username is exist !");

                return Ok(data);
            }
            data.Remove("data");
            data.Add("data", user);

            return Ok(data);
        }


        [HttpGet("me")]
        public async Task<IActionResult> getUser()
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase));
            if (claim == null)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Invalid token !");
                return Unauthorized(data);
            }
            AppUser user = await _userService.GetById(Int32.Parse(claim.Value));
            if (user == null)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Username is not exist !");

                return BadRequest(data);
            }
            data.Remove("data");
            data.Add("data", user);

            return Ok(data);
        }

        [HttpPut("me")]
        public async Task<IActionResult> updateUser([FromBody] AppUser appUser)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase));
            if (claim == null)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Invalid token !");
                return Unauthorized(data);
            }
            AppUser user = await _userService.UpdateById(Int32.Parse(claim.Value), appUser);
            if (user == null)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Username is exist !");

                return Ok(data);
            }
            data.Remove("data");
            data.Add("data", user);

            return Ok(data);
        }


        [HttpGet]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] AppUser appUser)
        {
            // only allow admins to access other user records
            //var currentUserId = int.Parse(User.Identity.Name);
            //if (id != currentUserId && !User.IsInRole(AppRole.Admin))
            //    return Forbid();

            var user = await _userService.GetById(appUser.Id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }



        [HttpDelete("DeleteById")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeleteById([FromBody] AppUser appUser)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            var delete = await _userService.DeleteUserById(appUser.Id);

            if (delete)
            {
                data.Add("message", "Delete user is successful !");

                return Ok(data);
            }
            data.Remove("status");
            data.Add("status", "WARNING");
            data.Add("message", "Delete user is failed !");


            return Ok(data);
        }

        [HttpPut("UpdateById")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateById([FromBody] AppUser appUser)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            //var user = await _userService.UpdateById(appUser);

            //if (user == null)
            //{

            //    data.Remove("status");
            //    data.Add("status", "WARNING");
            //    data.Add("message", "Update user is failed !");


            //    return Ok(data);
            //}

            //data.Remove("data");
            //data.Add("data", user);
            //data.Add("message", "Update user is successful !");


            return Ok(data);
        }
    }
}
