using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VulcanizationAPI.ControllerServices;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.Controllers
{
    [Route("api/vulcanization")]
    [ApiController]
    [Authorize]
    public class VulcanizationController : ControllerBase
    {

        private readonly IVulcanizationService _vulcanizationService;

        public VulcanizationController(IVulcanizationService vulcanizationService)
        {
            _vulcanizationService = vulcanizationService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateVulcanization([FromBody] CreateVulcanizationDto dto)
        {
            var result = _vulcanizationService.Create(dto);

            return Created($"/api/vulcanization/{result}", null);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VulcanizationDto>>> GetAll()
        {
            var vulcanizationsDtos = await _vulcanizationService.GetAll();

            return Ok(vulcanizationsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<VulcanizationDto> Get([FromRoute] int id)
        {
            var vulcanization = _vulcanizationService.GetById(id);

            return Ok(vulcanization);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _vulcanizationService.Delete(id);

            return NoContent();

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromBody] CreateVulcanizationDto dto, [FromRoute] int id)
        {
            _vulcanizationService.Update(id, dto);

            return Ok();
        }
    }
}
