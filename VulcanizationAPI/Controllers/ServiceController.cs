using Microsoft.AspNetCore.Mvc;
using VulcanizationAPI.ControllerServices;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization/{vulcanizationId}/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly VulcanizationDbContext _dbContext;

        public ServiceController(IServiceService serviceService, VulcanizationDbContext dbContext)
        {
            _serviceService = serviceService;
            _dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult CreateService([FromRoute] int vulcanizationId, [FromBody] CreateServiceDto dto)
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
        [HttpPut("{serviceId}")]
        public ActionResult Update([FromRoute] int vulcanizationId, [FromRoute] int serviceId, [FromBody] CreateServiceDto dto)
        {
            _serviceService.Update(vulcanizationId, serviceId, dto);

            return Ok();
        }
        [HttpDelete("{serviceId}")]
        public ActionResult Delete([FromRoute] int vulcanizationId, [FromRoute] int serviceId)
        {
            _serviceService.DeleteService(vulcanizationId, serviceId);

            return NoContent();
        }
    }
}
