using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class DNDCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public List<ModeInCategory> ModeInCategories { get; set; }

    }
}
