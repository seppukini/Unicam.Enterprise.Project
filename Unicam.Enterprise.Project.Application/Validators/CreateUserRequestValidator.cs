using FluentValidation;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
        
        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .Must(IsStrongPassword).WithMessage("Password must contain at least one uppercase letter, one lowercase " +
                                                "letter, one number and one special character");
        
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name is required");
        
        RuleFor(e => e.Surname)
            .NotEmpty().WithMessage("Surname is required");
    }
    
    private static bool IsStrongPassword(string password)
    {
        return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && 
               password.Any(char.IsPunctuation);
    }
}