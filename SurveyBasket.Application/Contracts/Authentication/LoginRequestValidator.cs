using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Contracts.Authentication;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();

    }
}

          

  