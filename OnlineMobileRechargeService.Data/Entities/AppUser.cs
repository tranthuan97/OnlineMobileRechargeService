using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class AppUser
    {
        public int FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
