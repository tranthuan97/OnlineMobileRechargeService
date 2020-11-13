using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int OperatorId { get; set; }
        public int VASId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Validate { get; set; }
        public int Description { get; set; }
    }
}
