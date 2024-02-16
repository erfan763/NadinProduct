using Microsoft.AspNetCore.Identity;

namespace Domin.Entities.User;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Token { get; set; }
}