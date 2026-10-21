using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Contracts.Authentication;

public record AuthResponse
(
    string Id,
    string? Email,
    string FirstName,
    string LastName,
    string Token,
    int ExpiresIn
); 
