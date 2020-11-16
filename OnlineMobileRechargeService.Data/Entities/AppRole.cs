using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public int Level { get; set; }
        public int Description { get; set; }
    }
}
