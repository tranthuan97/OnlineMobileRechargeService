using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class PBPTransaction
    {
        public int Id { get; set; }
        public int PhoneNumber{ get; set; }
        public int Price { get; set; }
        public int CreatedDate { get; set; }

    }
}
