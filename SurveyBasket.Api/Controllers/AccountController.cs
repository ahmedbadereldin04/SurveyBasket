namespace SurveyBasket.Api.Controllers;

[Route("me")]
[ApiController]
[Authorize]
public class AccountController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("")]
    public async Task<IActionResult> Info(CancellationToken cancellationToken = default)
    {
        var result = await _userService.GetProfileAsync(User.GetUserId()!, cancellationToken);
        return Ok(result.Value);
    }

    [HttpPut("info")]
    public async Task<IActionResult> Update([FromBody] UpdateProfileRequest request, CancellationToken cancellationToken = default)
    {
        await _userService.UpdateProfileAsync(User.GetUserId()!, request);
        return NoContent();
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _userService.ChangePasswordAsync(User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
