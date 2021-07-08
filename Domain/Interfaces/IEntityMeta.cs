using System;

namespace Domain.Interfaces
{
    public interface IEntityMeta
    {
        string CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }

        string UpdatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}