using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Models.DTOs;

namespace VulcanizationAPI.Infrastructure.Services.Abstract
{
    public interface IVulcanizationService
    {
        Task Create(CreateVulcanizationDto dto);
        Task<IEnumerable<VulcanizationDto>> GetAll();
        Task<VulcanizationDto> GetById(int id);
        Task Delete(int id);
        Task Update(int id, CreateVulcanizationDto dto);
    }
}
