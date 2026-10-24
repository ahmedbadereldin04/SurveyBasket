using SurveyBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Interfaces;

public interface IJwtProvider
{
    (string Token,int ExpiresIn) GenerateToken(ApplicationUser user);
    string? ValidateToken(string token);
}
