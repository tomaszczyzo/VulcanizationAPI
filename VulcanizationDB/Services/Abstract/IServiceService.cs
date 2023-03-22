using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Models.DTOs;

namespace VulcanizationAPI.Infrastructure.Services.Abstract
{
    public interface IServiceService
    {
        Task Create(long vulcanizationId, CreateServiceDto dto);
        Task<ServiceDto> GetById(long vulcanizationId, long serviceId);
        Task<List<ServiceDto>> GetAll(long vulcanizationId);
        Task DeleteService(long vulcanizationId, long serviceId);
        Task Update(long vulcanizationId, long serviceId, CreateServiceDto dto);
    }
}
