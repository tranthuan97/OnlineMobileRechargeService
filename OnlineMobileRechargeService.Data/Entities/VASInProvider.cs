using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Entities
{
    public class VASInProvider
    {
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        
        public int VASId { get; set; }
        public VAS VAS { get; set; }
    }
}
