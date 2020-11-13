using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class DNDTransaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryName { get; set; }
        public int ModeName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int CreatedDate { get; set; }
        public int Status { get; set; }
    }
}
