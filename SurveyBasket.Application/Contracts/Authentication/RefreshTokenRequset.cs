namespace SurveyBasket.Application.Contracts.Authentication;

public record RefreshTokenRequset
(
    string Token,
    string RefreshToken
);