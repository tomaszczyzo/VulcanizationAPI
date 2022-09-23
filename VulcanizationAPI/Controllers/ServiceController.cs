using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.ControllerServices;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization/{vulcanizationId}/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpPost]
        public ActionResult CreateService([FromRoute]int vulcanizationId, [FromBody]CreateServiceDto dto)
        {
            var newServiceId = _serviceService.Create(vulcanizationId, dto);

            return Created($"api/vulcanization/{vulcanizationId}/service/{newServiceId}", null);
        }
        [HttpGet("{serviceId}")]
        public ActionResult<ServiceDto> GetService([FromRoute] int vulcanizationId, [FromRoute] int serviceId)
        {
            var service = _serviceService.GetById(vulcanizationId, serviceId);

            return Ok(service);
        }
        [HttpGet]
        public ActionResult<List<ServiceDto>> GetAll([FromRoute] int vulcanizationId)
        {
            var serviceDtos = _serviceService.GetAll(vulcanizationId);

            return Ok(serviceDtos);
        }
        [HttpDelete("{serviceId}")]
        public ActionResult Delete([FromRoute] int vulcanizationId, [FromRoute] int serviceId)
        {
            _serviceService.DeleteService(vulcanizationId, serviceId);

            return NoContent();
        }
    }
}
