using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Application.Repository.Operator
{
    public interface IOperatorService
    {
        Task<ICollection<Provider>> GetAll();
    }
}
