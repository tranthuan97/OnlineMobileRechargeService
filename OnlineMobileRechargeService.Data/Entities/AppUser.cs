using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public int FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

        public List<UserInPlan> UserInPlans { get; set; }
        public List<Transaction> Transactions{ get; set; }
        public List<DNDTransaction> DNDTransactions{ get; set; }
        
    }
}
