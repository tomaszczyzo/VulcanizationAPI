using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Data;
using VulcanizationAPI.Infrastructure.Services.Abstract;
using VulcanizationAPI.Infrastructure.Services.Concrete;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization/{vulcanizationId}/service")]
    [ApiController]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult> CreateService([FromRoute] int vulcanizationId, [FromBody] CreateServiceDto dto)
        {
            await _serviceService.Create(vulcanizationId, dto);

            return Ok();
        }

        [HttpGet("{serviceId}")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceDto>> GetService([FromRoute] int vulcanizationId, [FromRoute] int serviceId)
        {
            var service = await _serviceService.GetById(vulcanizationId, serviceId);

            return Ok(service);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ServiceDto>>> GetAll([FromRoute] int vulcanizationId)
        {
            var serviceDtos = await _serviceService.GetAll(vulcanizationId);

            return Ok(serviceDtos);
        }

        [HttpPut("{serviceId}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult> Update([FromRoute] int vulcanizationId, [FromRoute] int serviceId, [FromBody] CreateServiceDto dto)
        {
            await _serviceService.Update(vulcanizationId, serviceId, dto);

            return Ok();
        }

        [HttpDelete("{serviceId}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult> Delete([FromRoute] int vulcanizationId, [FromRoute] int serviceId)
        {
            await _serviceService.DeleteService(vulcanizationId, serviceId);

            return Ok();
        }
    }
}
