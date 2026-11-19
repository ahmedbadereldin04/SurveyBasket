namespace SurveyBasket.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool? includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<RoleDetailsResponse>> GetAsync(string id);
    Task<Result<RoleDetailsResponse>> AddAsync(RoleRequest request);
}
