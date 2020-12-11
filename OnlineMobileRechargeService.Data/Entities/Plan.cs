using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public int VASId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Validate { get; set; }
        public string Description { get; set; }

        public Provider Provider { get; set; }
        public VAS VAS { get; set; }
        public List<UserInPlan> UserInPlans { get; set; }
        public List<GuestTransaction> GuestTransactions { get; set; }

    }
}
