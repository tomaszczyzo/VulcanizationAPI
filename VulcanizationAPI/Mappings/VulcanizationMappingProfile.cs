﻿using AutoMapper;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Entities.Concrete;
using VulcanizationAPI.Core.Models.DTOs;

namespace VulcanizationAPI.Mappings
{
    public class VulcanizationMappingProfile : Profile
    {
        public VulcanizationMappingProfile()
        {
            CreateMap<Vulcanization, VulcanizationDto>()
                .ForMember(x => x.City, c => c.MapFrom(z => z.Address.City))
                .ForMember(x => x.Street, c => c.MapFrom(z => z.Address.Street))
                .ForMember(x => x.PostalCode, c => c.MapFrom(z => z.Address.PostalCode))
                .ForMember(x => x.Email, c => c.MapFrom(z => z.Contact.Email))
                .ForMember(x => x.PhoneNumber, c => c.MapFrom(z => z.Contact.PhoneNumber));

            CreateMap<Service, ServiceDto>();

            CreateMap<CreateVulcanizationDto, Vulcanization>()
                .ForMember(x => x.Address, c => c.MapFrom(dto => new Address()
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }))
                .ForMember(x => x.Contact, c => c.MapFrom(dto => new Contact()
                {
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                }));
            CreateMap<CreateServiceDto, Service>();
            CreateMap<Service, CreateServiceDto>();
        }
    }
}
