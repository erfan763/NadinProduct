using System.ComponentModel.DataAnnotations;

namespace Domin.Common.BaseEntity;

public abstract class BaseEntity
{
    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    [Key] public int Id { get; set; }
}