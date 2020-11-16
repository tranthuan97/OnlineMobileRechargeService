using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class VASInOperator
    {
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        
        public int VASId { get; set; }
        public VAS VAS { get; set; }
    }
}
