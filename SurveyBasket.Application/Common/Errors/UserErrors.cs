namespace SurveyBasket.Application.Common.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials = 
        new("User.InvalidCredentials", "Invalid email or password", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidJwtToken =
        new("User.InvalidJwtToken", "Invalid Jwt token", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
        new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicatedEmail =
        new("User.DuplicatedEmail", "Another user with this email already exists", StatusCodes.Status409Conflict);

    public static readonly Error EmailNotConfirmed =
        new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);
    public static readonly Error InvalidCode =
        new("User.Invalid", "Invalid code", StatusCodes.Status401Unauthorized);
    public static readonly Error DuplicatedConfirmation =
        new("User.DuplicatedConfirmation", "Email already cofirmed", StatusCodes.Status400BadRequest);


}
