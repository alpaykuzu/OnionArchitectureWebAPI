
using FluentValidation;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(2)
                .WithName("İsim ve Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(5)
                .EmailAddress()
                .WithName("E-posta Adresi");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(6)
                .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Parola Doğrulama");
        }
    }
}
