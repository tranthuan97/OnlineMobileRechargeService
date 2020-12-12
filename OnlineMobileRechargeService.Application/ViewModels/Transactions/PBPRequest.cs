using System;
namespace OnlineMobileRechargeService.Application.ViewModels.Transactions
{
    public class PBPRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Price{ get; set; }
        public string PaymentCard{ get; set; }
    }
}
