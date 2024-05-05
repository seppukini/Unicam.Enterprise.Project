using FluentValidation;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Validators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(e => e.DeliveryAddress)
            .NotEmpty().WithMessage("Delivery Address id Required");

        RuleFor (e => e.CourseIds)
            .NotEmpty().WithMessage("Course Ids Should not be Empty");
    }
}