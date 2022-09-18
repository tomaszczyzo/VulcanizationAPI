using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Entities;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization")]
    public class VulcanizationController : ControllerBase
    {
        private readonly VulcanizationDbContext _dbContext;

        public VulcanizationController(VulcanizationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vulcanization>> GetAll()
        {
            var vulcanizations = _dbContext
                .Vulcanizations
                .ToList();

            return Ok(vulcanizations);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Vulcanization> Get([FromRoute] int id)
        {
            var vulcanization = _dbContext
                .Vulcanizations
                .FirstOrDefault(r => r.Id == id);

            if(vulcanization is null)
            {
                return NotFound();
            }
            return Ok(vulcanization);
        }
    }
}
