using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class CallerTune
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        public string Audio { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
