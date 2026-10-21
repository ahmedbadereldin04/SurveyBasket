using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SurveyBasket.Application.Contracts.Authentication;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Infrastructure.Services;

public class AuthService(UserManager<ApplicationUser> userManager,IJwtProvider jwtProvider) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

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


        //return token
        return new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn * 60);



    }
}
