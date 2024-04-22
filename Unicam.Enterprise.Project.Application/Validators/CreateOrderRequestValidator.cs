using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(e => e.DeliveryAddress)
                .NotEmpty().WithMessage(" Devilery Address id Required ");

            RuleFor (e => e.CourseIds)
                .NotEmpty().WithMessage(" Course Ids Should not be Empty ");
        }
    }
}
