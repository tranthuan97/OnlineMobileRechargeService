using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class VAS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OperatorId { get; set; }

        public Operator Operator { get; set; }
    }
}
