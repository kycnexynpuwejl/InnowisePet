using InnowisePet.IdentityServer4.Models.DTO;
using InnowisePet.IdentityServer4.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.IdentityServer4.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAccountService _accountService;


    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    ///     Creates a new user
    /// </summary>
    /// <param name="userForCreation"></param>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserForCreationDto userForCreation)
    {
        await _accountService.CreateUser(userForCreation);
        return Ok();
    }

    /// <summary>
    ///     Add role to user
    ///     | Required role: Administrator
    /// </summary>
    /// <param name="login"></param>
    /// <param name="role"></param>
    [HttpPost]
    [Route("addrole")]
    [Authorize]
    public async Task<IActionResult> AddRoleToUser([FromQuery] string login, [FromQuery] string role)
    {
        await _accountService.AddRoleToUser(login, role);
        return Ok();
    }

    /// <summary>
    ///     Remove role from user
    ///     | Required role: Administrator
    /// </summary>
    /// <param name="login"></param>
    /// <param name="role"></param>
    [HttpPost]
    [Route("removerole")]
    [Authorize]
    public async Task<IActionResult> RemoveRoleFromUser([FromQuery] string login, [FromQuery] string role)
    {
        await _accountService.RemoveRoleFromUser(login, role);
        return Ok();
    }

    /// <summary>
    ///     Authenticate user by username and password
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Returns access token for authenticated user</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        AuthenticatedUserInfo userInfo = await _accountService.AuthenticateUser(user);
        return Ok(userInfo);
    }
}