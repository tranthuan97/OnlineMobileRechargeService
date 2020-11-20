using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class DNDTransaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DNDCategoryId { get; set; }
        public int DNDModeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public AppUser AppUser{ get; set; }
        public DNDCategory DNDCategory { get; set; }
        public DNDMode DNDMode { get; set; }




    }
}
