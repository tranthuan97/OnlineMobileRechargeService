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

        public List<VASInOperator> VASInOperators { get; set; }
        public List<Plan> Plans { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
