using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnlineMobileRechargeService.Application.Repository.User;
using OnlineMobileRechargeService.Application.ViewModels.Users;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = AppRole.Admin)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public string DecodeToken(string token)
        {
            if (token == null)
            {
                return "";
            }
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

            return tokenS.Claims.First(claim => claim.Type == "role").Value;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            
            data.Add("data", null);
            var user = await _userService.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                //return BadRequest(new { message = "Username or password is incorrect" });
                data.Remove("status");
                data.TryAdd("status", "WARNING");
                data.Add("message", "Tài khoản hoặc mật khẩu không đúng !");
                return Ok(data);
            }
            data.Remove("data");
            data.Add("data", user);

            Console.WriteLine(DecodeToken(user.Token));
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
                data.Add("status", "Username is exist !");

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
                data.Add("status", "Username is exist !");

                return Ok(data);
            }
            data.Remove("data");
            data.Add("data", user);

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // only allow admins to access other user records
            //var currentUserId = int.Parse(User.Identity.Name);
            //if (id != currentUserId && !User.IsInRole(AppRole.Admin))
            //    return Forbid();

            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
