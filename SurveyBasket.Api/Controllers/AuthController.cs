using Microsoft.AspNetCore.Http.HttpResults;
using SurveyBasket.Application.Common.Results;

namespace SurveyBasket.Api.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

        return authResult.IsSuccess
             ? Ok(authResult.Value)
            : Problem(statusCode: StatusCodes.Status400BadRequest, title: authResult.Error.Code, detail: authResult.Error.Description);
    }


    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequset request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return authResult.IsSuccess
            ? Ok()
            : Problem(statusCode: StatusCodes.Status400BadRequest, title: authResult.Error.Code, detail: authResult.Error.Description);
    }
    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> Revoke([FromBody] RefreshTokenRequset request, CancellationToken cancellationToken)
    {
        var result = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return result.IsSuccess 
            ? Ok() 
            : Problem(statusCode: StatusCodes.Status400BadRequest, title: result.Error.Code, detail: result.Error.Description);
    }
    
}
