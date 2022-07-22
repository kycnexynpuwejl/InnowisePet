using AutoMapper;
using InnowisePet.IdentityServer4.Models;
using InnowisePet.IdentityServer4.Models.DTO;
using InnowisePet.IdentityServer4.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InnowisePet.IdentityServer4.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IAuthenticationManager _authManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public AccountService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager,
        IAuthenticationManager authManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _authManager = authManager;
        _mapper = mapper;
    }

    public async Task AddRoleToUser(string login, string role)
    {
        AppUser user = await _userManager.FindByNameAsync(login);

        if (user == null)
            throw new Exception("User not found");

        if (!await _roleManager.RoleExistsAsync(role))
            throw new Exception("Role not exists");

        await _userManager.AddToRoleAsync(user, role);
    }

    public async Task RemoveRoleFromUser(string login, string role)
    {
        AppUser user = await _userManager.FindByNameAsync(login);

        if (user == null)
            throw new Exception("User not found");

        if (!await _roleManager.RoleExistsAsync(role))
            throw new Exception("Role not exists");

        await _userManager.RemoveFromRoleAsync(user, role);
    }

    public async Task<AuthenticatedUserInfo> AuthenticateUser(UserForAuthenticationDto user)
    {
        AppUser validUser = await _authManager.ReturnUserIfValid(user);

        if (validUser == null) throw new Exception("Unauthorized");

        (string accessToken, string refreshToken) tokens = await _authManager.GetTokens(user);

        return new AuthenticatedUserInfo
        {
            AccessToken = tokens.accessToken,
            RefreshToken = tokens.refreshToken,
            UserRoles = await _userManager.GetRolesAsync(validUser)
        };
    }

    public async Task CreateUser(UserForCreationDto userForCreation)
    {
        AppUser user = _mapper.Map<AppUser>(userForCreation);

        IdentityResult result = await _userManager.CreateAsync(user, userForCreation.Password);

        if (!result.Succeeded)
        {
            string errors = "";
            foreach (IdentityError error in result.Errors) errors += $"{error.Code}: {error.Description}\n";
            throw new Exception(errors);
        }
    }
}