using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Models.DTOs;

namespace VulcanizationAPI.Infrastructure.Services.Abstract
{
    public interface IAccountService
    {
        Task<string> GenerateJwt(LoginDto dto);
        Task RegisterUser(RegisterUserDto dto);
    }
}
