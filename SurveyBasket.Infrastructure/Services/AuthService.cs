using Microsoft.AspNetCore.Identity;
using SurveyBasket.Application.Contracts.Authentication;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Domain.Entities;
using System.Security.Cryptography;

namespace SurveyBasket.Infrastructure.Services;

public class AuthService(UserManager<ApplicationUser> userManager,IJwtProvider jwtProvider) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly int _refreshTokenExpiryDays = 14; // Default expiration time in days
    public async Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        //chech user?
        var user = await _userManager.FindByEmailAsync(email);

        if(user is null)
            return null;

        //check password?
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

        if(!isPasswordValid)
            return null;


        //generate jwt token
        var(token, expiresIn) = _jwtProvider.GenerateToken(user);


        //generate refresh token
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });
        await _userManager.UpdateAsync(user);


        //return token
        return new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn * 60, refreshToken, refreshTokenExpiration);

    }

    public async Task<AuthResponse?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);

        if (userId is null)
            return null;

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return null;

        var userRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken && rt.IsActive);

        if(userRefreshToken is null)
            return null;

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        var (newToken, expiresIn) = _jwtProvider.GenerateToken(user);
        var newRefreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            ExpiresOn = refreshTokenExpiration
        });
        await _userManager.UpdateAsync(user);

        return new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, newToken, expiresIn * 60, newRefreshToken, refreshTokenExpiration);

    }

    public async Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);

        if (userId is null)
            return false;

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return false;

        var userRefreshToken = user.RefreshTokens.SingleOrDefault(rt => rt.Token == refreshToken && rt.IsActive);

        if(userRefreshToken is null)
            return false;

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return true;
    }

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}
