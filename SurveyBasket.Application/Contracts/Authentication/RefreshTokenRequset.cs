using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Contracts.Authentication;

public record RefreshTokenRequset
(
    string Token,
    string RefreshToken
);