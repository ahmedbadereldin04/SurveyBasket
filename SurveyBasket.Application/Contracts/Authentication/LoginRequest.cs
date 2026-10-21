using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);

