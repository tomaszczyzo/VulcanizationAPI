using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization")]
    public class VulcanizationController : ControllerBase
    {
        private readonly VulcanizationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VulcanizationController(VulcanizationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VulcanizationDto>> GetAll()
        {
            var vulcanizations = _dbContext
                .Vulcanizations
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .ToList();

            var vulcanizationsDtos = _mapper.Map<List<VulcanizationDto>>(vulcanizations);

            return Ok(vulcanizationsDtos);
        }
        
        [HttpGet("{id}")]
        public ActionResult<VulcanizationDto> Get([FromRoute] int id)
        {
            var vulcanization = _dbContext
                .Vulcanizations
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .FirstOrDefault(r => r.Id == id);

            if(vulcanization is null)
            {
                return NotFound();
            }

            var vulcanizationDto = _mapper.Map<VulcanizationDto>(vulcanization);

            return Ok(vulcanizationDto);
        }
    }
}
