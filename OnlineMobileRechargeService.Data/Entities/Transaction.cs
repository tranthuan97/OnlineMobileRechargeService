using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int OperatorId { get; set; }
        public int SimtypeId { get; set; }
        public Guid UserId { get; set; }
        public int VASId { get; set; }
        public decimal Price { get; set; }
        public string PaymentCard { get; set; }
        public DateTime CreatedDate { get; set; }

        public Operator Operator { get; set; }
        public AppUser AppUser { get; set; }
        public VAS VAS { get; set; }
    }
}
