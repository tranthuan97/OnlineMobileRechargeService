using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly OMRSDbContext _dbContext;

        public PlansController(OMRSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Plans
        [HttpGet]
        public ActionResult<IEnumerable<Plan>> Get()
        {
            return _dbContext.Plans.ToList();
        }

        // GET: api/Plans/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Plans
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
