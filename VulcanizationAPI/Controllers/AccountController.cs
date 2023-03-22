using Microsoft.AspNetCore.Mvc;
using VulcanizationAPI.Core.Models.Authentication;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Services.Abstract;
using VulcanizationAPI.Infrastructure.Services.Concrete;

namespace VulcanizationAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            string token = await _accountService.GenerateJwt(dto);

            return Ok(new AuthenticatedResponse { Token = token });
        }
    }
}
