using System.ComponentModel.DataAnnotations;

namespace Domin.Common.BaseEntity;

public interface IEntity : ITimeModification
{
}

public interface ITimeModification
{
    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}

public abstract class BaseEntity
{
    [Key] public string Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}