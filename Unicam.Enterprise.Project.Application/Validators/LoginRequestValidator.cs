using FluentValidation;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}