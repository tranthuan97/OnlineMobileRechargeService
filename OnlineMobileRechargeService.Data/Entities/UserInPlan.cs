using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class UserInPlan
    {
        public Guid UserId{ get; set; }
        public AppUser AppUser{ get; set; }

        public int PlanId{ get; set; }
        public Plan Plan{ get; set; }
    }
}
