namespace SurveyBasket.Application.Contracts.Authentication;

public class RefreshTokenRequsetValidator : AbstractValidator<RefreshTokenRequset>
{
    public RefreshTokenRequsetValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x => x.RefreshToken)
            .NotEmpty();
    }

}
