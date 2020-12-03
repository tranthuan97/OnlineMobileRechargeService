using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class PBPTransaction
    {
        public int Id { get; set; }
        public int PhoneNumber{ get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
