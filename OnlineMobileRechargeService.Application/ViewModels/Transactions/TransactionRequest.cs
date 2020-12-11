using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.ViewModels.Transactions
{
    public class TransactionRequest
    {
        public int PlanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentCard { get; set; }
        public bool PaymentMethod { get; set; }
    }
}
