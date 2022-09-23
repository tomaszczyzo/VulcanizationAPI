using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Exceptions;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.ControllerServices
{
    public interface IServiceService
    {
        int Create(int vulcanizationId, CreateServiceDto dto);
        ServiceDto GetById(int vulcanizationId, int serviceId);
        List<ServiceDto> GetAll(int vulcanizationId);
        void DeleteService(int vulcanizationId, int serviceId);
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
        public int Create(int vulcanizationId, CreateServiceDto dto)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var vulcanizationEntity = _mapper.Map<Service>(dto);

            vulcanizationEntity.VulcanizationId = vulcanizationId;
            _context.Services.Add(vulcanizationEntity);
            _context.SaveChanges();

            return vulcanizationEntity.Id;
        }
        public ServiceDto GetById(int vulcanizationId, int serviceId)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);


            var service = GetServiceById(serviceId, vulcanizationId);


            var result = _mapper.Map<ServiceDto>(service);

            return result;
        }
        public List<ServiceDto> GetAll(int vulcanizationId)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var result = _mapper.Map<List<ServiceDto>>(vulcanization.Services);

            return result;
        }
        public void DeleteService(int vulcanizationId, int serviceId)
        {
            var vulcanization = GetVulcanizationById(vulcanizationId);

            var service = GetServiceById(serviceId, vulcanizationId);

            _context.Services.Remove(service);
            _context.SaveChanges();


        }

        private Vulcanization GetVulcanizationById(int vulcanizationId)
        {
            var vulcanization = _context
                .Vulcanizations
                .Include(r => r.Services)
                .FirstOrDefault(r => r.Id == vulcanizationId);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found.");

            return vulcanization;
        }

        private Service GetServiceById(int serviceId, int vulcanizationId)
        {
            var service = _context.Services.FirstOrDefault(r => r.Id == serviceId);
            if (service is null || service.VulcanizationId != vulcanizationId)
                throw new NotFoundException("Service not found.");

            return service;
        }

    }
}
