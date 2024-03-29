﻿using Domin.Common.BaseEntity;
using Domin.Entities.Product;
using Microsoft.AspNetCore.Identity;

namespace Domin.Entities.User;

public class User : IdentityUser, IEntity

{

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public virtual ICollection<Product.Product> Products { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}