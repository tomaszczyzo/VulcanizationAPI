using FluentValidation;
using VulcanizationAPI.Entities;

namespace VulcanizationAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(VulcanizationDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Your e-mail cannot be empty.")
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(5).WithMessage("Your password length must be at least 5.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");


            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email already in use.");
                    }
                });

        }
    }
}
