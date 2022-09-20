using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VulcanizationAPI.ControllerServices;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization")]
    public class VulcanizationController : ControllerBase
    {
       
        private readonly IVulcanizationService _vulcanizationService;

        public VulcanizationController(IVulcanizationService vulcanizationService)
        {
            _vulcanizationService = vulcanizationService;
        }
        

        [HttpPost]
        public ActionResult CreateVulcanization([FromBody] CreateVulcanizationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _vulcanizationService.Create(dto);

            return Created($"/api/vulcanization/{result}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<VulcanizationDto>> GetAll()
        {

            var vulcanizationsDtos = _vulcanizationService.GetAll();

            return Ok(vulcanizationsDtos);
        }
        
        [HttpGet("{id}")]
        public ActionResult<VulcanizationDto> Get([FromRoute] int id)
        {
            var vulcanization = _vulcanizationService.GetById(id);

            if(vulcanization is null)
            {
                return NotFound();
            }


            return Ok(vulcanization);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _vulcanizationService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
