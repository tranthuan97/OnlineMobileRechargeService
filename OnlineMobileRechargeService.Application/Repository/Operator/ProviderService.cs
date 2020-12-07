using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.Repository.Operator
{
    public class ProviderService : IProviderService
    {
        private readonly OMRSDbContext _dbContext;

        public ProviderService(OMRSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            var provider = await _dbContext.Providers.ToListAsync();
            return provider;
        }
    }
}
