using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int SimtypeId { get; set; }
        public int UserId { get; set; }
        public int VASId { get; set; }
        public decimal Price { get; set; }
        public string PaymentCard { get; set; }
        public DateTime CreatedDate { get; set; }

        public SimType SimType { get; set; }
        public Provider Provider { get; set; }
        public AppUser AppUser { get; set; }
        public VAS VAS { get; set; }
    }
}
