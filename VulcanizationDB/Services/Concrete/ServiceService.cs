using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Data.Repositories.Abstract;
using VulcanizationAPI.Infrastructure.Services.Abstract;

namespace VulcanizationAPI.Infrastructure.Services.Concrete
{

    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly IVulcanizationRepository _vulcanizationRepository;

        public ServiceService(IMapper mapper,
            IServiceRepository serviceRepository,
            IVulcanizationRepository vulcanizationRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _vulcanizationRepository = vulcanizationRepository;
        }

        public async Task Create(long vulcanizationId, CreateServiceDto dto)
        {
            var vulcanizationEntity = _mapper
                .Map<Service>(dto);

            vulcanizationEntity.VulcanizationId = vulcanizationId;
            await _serviceRepository
                .AddAsync(vulcanizationEntity);
        }

        public async Task<ServiceDto> GetById(long vulcanizationId, long serviceId)
        {
            var service = await _serviceRepository.FindSingleAsync(s => s.Id == serviceId && s.VulcanizationId == vulcanizationId);

            var result = _mapper.Map<ServiceDto>(service);

            return result;
        }

        public async Task<List<ServiceDto>> GetAll(long vulcanizationId)
        {
            var vulcanization = await GetVulcanizationById(vulcanizationId);

            var result = _mapper.Map<List<ServiceDto>>(vulcanization.Services);

            return result;
        }

        public async Task DeleteService(long vulcanizationId, long serviceId)
        {
            var service = await _serviceRepository.FindSingleAsync(s => s.Id == serviceId && s.VulcanizationId == vulcanizationId);

            _serviceRepository.Delete(service);
        }

        public async Task Update(long vulcanizationId, long serviceId, CreateServiceDto dto)
        {
            var vulcanization = await GetVulcanizationById(vulcanizationId);

            var service = await _serviceRepository.GetByIdAsync(serviceId);

            service.Name = dto.Name;
            service.Description = dto.Description;
            service.Price = dto.Price;

            _serviceRepository.Update(service);
        }

        private async Task<Vulcanization> GetVulcanizationById(long vulcanizationId)
        {
            var vulcanization = await _vulcanizationRepository
                    .FindSingleAsync(v => v.Id == vulcanizationId);

            return vulcanization;
        }
    }
}
