using Newtonsoft.Json;

namespace InnowisePet.IdentityServer4.Models.DTO;

public class AddRoleDto
{ 
    [JsonProperty("login")]
    public string UserName { get; set; }
    
    [JsonProperty("role")] 
    public string Role { get; set; }
}