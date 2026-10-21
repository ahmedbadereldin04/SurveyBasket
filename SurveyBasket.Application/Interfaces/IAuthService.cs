using SurveyBasket.Application.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
}
