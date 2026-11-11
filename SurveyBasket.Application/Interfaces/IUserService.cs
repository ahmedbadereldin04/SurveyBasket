using SurveyBasket.Application.Contracts.Users;

namespace SurveyBasket.Application.Interfaces;

public interface IUserService
{
    Task<Result<UserProfileResponse>> GetProfileAsync(string userId, CancellationToken cancellationToken = default);
}
