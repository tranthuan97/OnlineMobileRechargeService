using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Offer
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int ProviderId{ get; set; }
        public string Image{ get; set; }
        public DateTime CreatedDate{ get; set; }
        public string Description{ get; set; }

        //khai bao de tao khoa ngoai
        public Provider Provider { get; set; }
    }
}
