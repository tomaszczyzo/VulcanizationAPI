using Microsoft.AspNetCore.Mvc;
using VulcanizationAPI.Core.Models.Authentication;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Services;

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
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok(dto);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);

            return Ok(new AuthenticatedResponse { Token = token });
        }
    }
}
