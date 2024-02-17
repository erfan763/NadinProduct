using Domin.Common.BaseEntity;
using Domin.Entities.User;

namespace Domin.Entities.Product;

public class Product : BaseEntity
{
    public bool IsAvailable { get; set; } = true;

    public string ManufactureEmail { get; set; }

    public string ManufacturePhone { get; set;}

    public string Name { get; set; }

    public string userId { get; set; }

    public virtual User.User User { get; set; }

}