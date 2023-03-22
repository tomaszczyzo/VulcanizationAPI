using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Exceptions;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Data;
using VulcanizationAPI.Infrastructure.Data.Repositories.Abstract;
using VulcanizationAPI.Infrastructure.Services.Abstract;

namespace VulcanizationAPI.Infrastructure.Services.Concrete
{
    public class VulcanizationService : IVulcanizationService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<VulcanizationService> _logger;
        private readonly IVulcanizationRepository _vulcanizationRepository;

        public VulcanizationService(IMapper mapper,
            ILogger<VulcanizationService> logger,
            IVulcanizationRepository vulcanizationRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _vulcanizationRepository = vulcanizationRepository;
        }

        public async Task<VulcanizationDto> GetById(int id)
        {
            var vulcanization = await _vulcanizationRepository
                .FindSingleAsync(v => v.Id == id, v => v.Address, v => v.Contact, v => v.Services);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found");

            var result = _mapper.Map<VulcanizationDto>(vulcanization);

            return result;
        }

        public async Task<IEnumerable<VulcanizationDto>> GetAll()
        {
            var vulcanizations = await _vulcanizationRepository.GetAllAsync();

            var result = _mapper.Map<List<VulcanizationDto>>(vulcanizations);

            return result;
        }

        public async Task Create(CreateVulcanizationDto dto)
        {
            var vulcanization = _mapper.Map<Vulcanization>(dto);
            await _vulcanizationRepository.AddAsync(vulcanization);

        }

        public async Task Delete(int id)
        {
            var vulcanization = await _vulcanizationRepository.GetByIdAsync(id);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found");

            _vulcanizationRepository.Delete(vulcanization);

        }

        public async Task Update(int id, CreateVulcanizationDto dto)
        {
            var vulcanization = await _vulcanizationRepository
                .FindSingleAsync(v => v.Id == id,
                v => v.Address,
                v => v.Contact);

            if (vulcanization is null)
                throw new NotFoundException("Vulcanization not found");

            vulcanization.Name = dto.Name;
            vulcanization.Description = dto.Description;
            vulcanization.Address.City = dto.City;
            vulcanization.Address.Street = dto.Street;
            vulcanization.Address.PostalCode = dto.PostalCode;
            vulcanization.Contact.Email = dto.Email;
            vulcanization.Contact.PhoneNumber = dto.PhoneNumber;

            _vulcanizationRepository.Update(vulcanization);

        }
    }
}
