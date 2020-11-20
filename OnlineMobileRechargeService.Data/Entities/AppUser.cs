using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public List<UserInPlan> UserInPlans { get; set; }
        public List<Transaction> Transactions{ get; set; }
        public List<DNDTransaction> DNDTransactions{ get; set; }
        
    }
}
