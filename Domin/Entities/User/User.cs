using Domin.Common.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Domin.Entities.User;

public class User : IdentityUser, IEntity

{
    //[Key] public string Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Token { get; set; } = "invalidToken";
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}