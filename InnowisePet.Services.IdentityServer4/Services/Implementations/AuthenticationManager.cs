using IdentityModel.Client;
using InnowisePet.IdentityServer4.Models;
using InnowisePet.IdentityServer4.Models.DTO;
using InnowisePet.IdentityServer4.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InnowisePet.IdentityServer4.Services.Implementations;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AuthenticationManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<AppUser> ReturnUserIfValid(UserForAuthenticationDto userForAuth)
    {
        AppUser user = await _userManager.FindByNameAsync(userForAuth.UserName);

        SignInResult res =
            await _signInManager.PasswordSignInAsync(userForAuth.UserName, userForAuth.Password, false, false);

        if (res.Succeeded) return user;
        return null;
    }

    public async Task<(string accessToken, string refreshToken)> GetTokens(UserForAuthenticationDto user)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        PasswordTokenRequest tokenRequest = new()
        {
            Address = "https://localhost:7000/connect/token",
            ClientId = "APIClient",
            Scope = "APIScope offline_access",
            UserName = user.UserName,
            Password = user.Password
        };
        TokenResponse tokenResponse = await client.RequestPasswordTokenAsync(tokenRequest);

        return (tokenResponse.AccessToken, tokenResponse.RefreshToken);
    }
}