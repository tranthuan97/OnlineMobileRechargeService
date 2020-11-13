using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Operator
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Logo{ get; set; }
        public string Description{ get; set; }


        //khai bao de tao khoa ngoai
        public List<Offer> Offers { get; set; }
    }
}
