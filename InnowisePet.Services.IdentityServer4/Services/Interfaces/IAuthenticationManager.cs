using InnowisePet.IdentityServer4.Models;
using InnowisePet.IdentityServer4.Models.DTO;

namespace InnowisePet.IdentityServer4.Services.Interfaces;

public interface IAuthenticationManager
{
    Task<AppUser> ReturnUserIfValid(UserForAuthenticationDto userForAuthentication);
    Task<(string accessToken, string refreshToken)> GetTokens(UserForAuthenticationDto user);
}