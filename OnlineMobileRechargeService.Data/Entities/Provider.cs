using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }


        //khai bao de tao khoa ngoai
        public List<Offer> Offers { get; set; }
        public List<VASInProvider> VASInProviders { get; set; }
        public List<Plan> Plans { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
