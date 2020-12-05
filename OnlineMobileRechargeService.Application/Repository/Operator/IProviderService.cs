using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.Repository.Operator
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetAll();
    }
}
