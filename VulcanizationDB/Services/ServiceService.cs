using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Exceptions;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Data;

namespace VulcanizationAPI.Infrastructure.Services
{
    public interface IServiceService
    {
        long Create(long vulcanizationId, CreateServiceDto dto);
        ServiceDto GetById(long vulcanizationId, long serviceId);
        List<ServiceDto> GetAll(long vulcanizationId);
        void DeleteService(long vulcanizationId, long serviceId);
        void Update(long vulcanizationId, long serviceId, CreateServiceDto dto);
    }

    public class ServiceService : IServiceService
    {
        private readonly VulcanizationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceService(VulcanizationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public long Create(long vulcanizationId, CreateServiceDto dto)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var vulcanizationEntity = _mapper.Map<Service>(dto);

            vulcanizationEntity.VulcanizationId = vulcanizationId;
            _context.Services.Add(vulcanizationEntity);
            _context.SaveChanges();

            return vulcanizationEntity.Id;
        }
        public ServiceDto GetById(long vulcanizationId, long serviceId)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);


            var service = GetServiceById(serviceId, vulcanizationId);


            var result = _mapper.Map<ServiceDto>(service);

            return result;
        }
        public List<ServiceDto> GetAll(long vulcanizationId)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var result = _mapper.Map<List<ServiceDto>>(vulcanization.Services);

            return result;
        }
        public void DeleteService(long vulcanizationId, long serviceId)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var service = GetServiceById(serviceId, vulcanizationId);

            _context.Services.Remove(service);
            _context.SaveChanges();

        }
        public void Update(long vulcanizationId, long serviceId, CreateServiceDto dto)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var service = GetServiceById(serviceId, vulcanizationId);


            service.Name = dto.Name;
            service.Description = dto.Description;
            service.Price = dto.Price;

            _context.SaveChanges();

        }

        private Vulcanization GetVulcanizationById(long vulcanizationId)
        {
            var vulcanization = _context
                .Vulcanizations
                .Include(r => r.Services)
                .FirstOrDefault(r => r.Id == vulcanizationId);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found.");

            return vulcanization;
        }

        private Service GetServiceById(long serviceId, long vulcanizationId)
        {
            var service = _context.Services.FirstOrDefault(r => r.Id == serviceId);
            if (service is null || service.VulcanizationId != vulcanizationId)
                throw new NotFoundException("Service not found.");

            return service;
        }

    }
}
