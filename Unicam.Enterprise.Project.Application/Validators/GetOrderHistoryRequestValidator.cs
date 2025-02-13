﻿using FluentValidation;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Validators;

public class GetOrderHistoryRequestValidator : AbstractValidator<GetOrderHistoryRequest>
{
    public GetOrderHistoryRequestValidator()
    {
        RuleFor(e => e.StartDate)
            .NotEmpty().WithMessage("Start Date must be Specified");

        RuleFor (e => e.EndDate)
            .NotEmpty().WithMessage ("Not a Date Found")
            .GreaterThan(elem => elem.StartDate).WithMessage("Start Date could not" +
                                                             " be forward then End Date");

        RuleFor(e => e.PageIndex)
            .NotEmpty().WithMessage("Index Page could not be an Empty Page")
            .GreaterThanOrEqualTo(1).WithMessage("At least one Index Page");

        RuleFor (e => e.PageSize)
            .NotEmpty().WithMessage("Must have some size")
            .GreaterThanOrEqualTo(1).WithMessage("At least size one");
    }
}