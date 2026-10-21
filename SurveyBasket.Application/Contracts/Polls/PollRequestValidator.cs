using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Contracts.Polls;

public class LoginRequestValidator : AbstractValidator<PollRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.Summary)
            .NotEmpty()
            .Length(3, 1500);

        RuleFor(x => x.StartsAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));

        RuleFor(x => x.EndsAt)
            .NotEmpty();

        RuleFor(x => x)
            .Must(HasValidDates)
            .WithName(nameof(PollRequest.EndsAt))
            .WithMessage("{PropertyName} must be greater than or equals start date ");
    }


    private bool HasValidDates(PollRequest request)
    {
        return request.EndsAt >= request.StartsAt;
    }
}
