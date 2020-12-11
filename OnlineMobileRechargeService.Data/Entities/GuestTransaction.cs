using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class GuestTransaction
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Simtype { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentCard { get; set; }
        public DateTime CreatedDate { get; set; }

        public Plan Plan { get; set; }
    }
}
