using Microsoft.AspNetCore.Identity;

namespace InnowisePet.IdentityServer4.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}