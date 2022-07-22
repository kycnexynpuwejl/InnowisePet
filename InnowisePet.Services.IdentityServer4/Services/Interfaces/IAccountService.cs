using InnowisePet.IdentityServer4.Models.DTO;

namespace InnowisePet.IdentityServer4.Services.Interfaces;

public interface IAccountService
{
    public Task<AuthenticatedUserInfo> AuthenticateUser(UserForAuthenticationDto user);
    public Task CreateUser(UserForCreationDto userForCreation);
    public Task AddRoleToUser(string login, string role);
    public Task RemoveRoleFromUser(string login, string role);
}