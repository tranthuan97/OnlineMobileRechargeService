using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class ModeInCategory
    {
        public int CategoryId { get; set; }
        public DNDCategory DNDCategory { get; set; }
        public int ModeId { get; set; }
        public DNDMode DNDMode { get; set; }

    }
}
