using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.EF
{
    class OMRSDbContext : DbContext
    {
        public OMRSDbContext( DbContextOptions options) : base(options)
        {
        }
    }
}
