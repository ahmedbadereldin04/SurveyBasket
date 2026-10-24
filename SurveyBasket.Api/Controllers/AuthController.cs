using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SurveyBasket.Application.Contracts.Authentication;
using SurveyBasket.Application.Interfaces;

namespace SurveyBasket.Api.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

        return authResult is null ? BadRequest("Invalid email or password") : Ok(authResult);
    }


    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequset request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return authResult is null ? BadRequest("Invalid token") : Ok(authResult);
    }
    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> Revoke([FromBody] RefreshTokenRequset request, CancellationToken cancellationToken)
    {
        var isRevoked = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return isRevoked ? Ok() : BadRequest("Operation failed") ;
    }
    
}
