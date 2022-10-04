using FluentValidation;
using VulcanizationAPI.Entities;

namespace VulcanizationAPI.Models.Validators
{
    public class CreateVulcanizationDtoValidator : AbstractValidator<CreateVulcanizationDto>
    {
        private const string PostalCodeValidator = @"^[0-9]{2}(\-[0-9]{3})$";
        private const string PhoneNumberValidator = @"^(\+48)?[0-9]{9}$";

        public CreateVulcanizationDtoValidator(VulcanizationDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Your Name cannot be empty.")
                .MaximumLength(35).WithMessage("Your password length must be below 35.");
            RuleFor(x => x.Description)
                .MaximumLength(400).WithMessage("Your Description length must be below 400.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Your City cannot be empty.")
                .MaximumLength(45).WithMessage("Your City length must be below 45.");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Your Street cannot be empty.")
                .MaximumLength(55).WithMessage("Your Street length must be below 55.")
                .Custom((value, context) =>
                {
                    var streetInUse = dbContext.Addresses.Any(u => u.Street == value);
                    if (streetInUse)
                    {
                        context.AddFailure("Street", "Address already in use.");
                    }
                });
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Your Postal Code cannot be empty.")
                .Matches(PostalCodeValidator);
            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(45).WithMessage("Your Email length must be below 45."); ;
            RuleFor(x => x.PhoneNumber)
                .Matches(PhoneNumberValidator);
        }
    }
}
