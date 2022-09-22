using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace VulcanizationAPI.ControllerServices
{
    public interface IVulcanizationService
    {
        int Create(CreateVulcanizationDto dto);
        IEnumerable<VulcanizationDto> GetAll();
        VulcanizationDto GetById(int id);
        bool Delete(int id);
        bool Update(int id, UpdateVulcanizationDto dto);
    }

    public class VulcanizationService : IVulcanizationService
    {
        private readonly VulcanizationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<VulcanizationService> _logger;

        public VulcanizationService(VulcanizationDbContext dbContext, IMapper mapper, ILogger<VulcanizationService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public VulcanizationDto GetById(int id)
        {
            var vulcanization = _dbContext
                .Vulcanizations
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .FirstOrDefault(r => r.Id == id);

            if (vulcanization is null)
                return null;

            var result = _mapper.Map<VulcanizationDto>(vulcanization);

            return result;
        }

        public IEnumerable<VulcanizationDto> GetAll()
        {
            var vulcanizations = _dbContext
                .Vulcanizations
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .ToList();

            var result = _mapper.Map<List<VulcanizationDto>>(vulcanizations);

            return result;
        }
        public int Create(CreateVulcanizationDto dto)
        {
            var vulcanization = _mapper.Map<Vulcanization>(dto);
            _dbContext.Vulcanizations.Add(vulcanization);
            _dbContext.SaveChanges();

            return vulcanization.Id;
        }
        public bool Delete(int id)
        {

            _logger.LogError($"Vulcanization with id: {id} DELETE action invoked");

            var vulcanization = _dbContext
                .Vulcanizations
                .FirstOrDefault(r => r.Id == id);


            if (vulcanization is null)
                return false;

            _dbContext.Vulcanizations.Remove(vulcanization);
            _dbContext.SaveChanges();

            return true;
        }
        public bool Update(int id, UpdateVulcanizationDto dto)
        {
            var vulcanization = _dbContext
                .Vulcanizations
                .FirstOrDefault(r => r.Id == id);

            if (vulcanization is null)
                return false;

            vulcanization.Name = dto.Name;
            vulcanization.Description = dto.Description;

            _dbContext.SaveChanges();

            return true;


        }
    }
}
