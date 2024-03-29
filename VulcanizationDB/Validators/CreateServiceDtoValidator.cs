﻿using FluentValidation;
using VulcanizationAPI.Core.Models.DTOs;

namespace VulcanizationAPI.Core.Validators
{
    public class CreateServiceDtoValidator 
        : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(45);
            RuleFor(x => x.Description)
                .MaximumLength(400);
            RuleFor(x => x.Price)
                .NotEmpty()
                .ScalePrecision(2, 9);
        }
    }
}
