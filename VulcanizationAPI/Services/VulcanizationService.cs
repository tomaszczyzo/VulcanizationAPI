using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Exceptions;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.ControllerServices
{
    public interface IVulcanizationService
    {
        int Create(CreateVulcanizationDto dto);
        Task<IEnumerable<VulcanizationDto>> GetAll();
        VulcanizationDto GetById(int id);
        void Delete(int id);
        void Update(int id, CreateVulcanizationDto dto);
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
                .Include(r => r.Services)
                .FirstOrDefault(r => r.Id == id);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found");

            var result = _mapper.Map<VulcanizationDto>(vulcanization);

            return result;
        }

        public async Task<IEnumerable<VulcanizationDto>> GetAll()
        {
            var vulcanizations = await _dbContext
                .Vulcanizations
                .AsQueryable()
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .Include(r => r.Services)
                .ToListAsync();

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
        public void Delete(int id)
        {


            var vulcanization = _dbContext
                .Vulcanizations
                .FirstOrDefault(r => r.Id == id);


            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found");

            _dbContext.Vulcanizations.Remove(vulcanization);
            _dbContext.SaveChanges();

        }
        public void Update(int id, CreateVulcanizationDto dto)
        {
            var vulcanization = _dbContext
                .Vulcanizations
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .FirstOrDefault(r => r.Id == id);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found");

            vulcanization.Name = dto.Name;
            vulcanization.Description = dto.Description;
            vulcanization.Address.City = dto.City;
            vulcanization.Address.Street = dto.Street;
            vulcanization.Address.PostalCode = dto.PostalCode;
            vulcanization.Contact.Email = dto.Email;
            vulcanization.Contact.PhoneNumber = dto.PhoneNumber;

            _dbContext.SaveChanges();

        }
    }
}
