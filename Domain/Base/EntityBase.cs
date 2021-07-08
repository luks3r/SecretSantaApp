using System;
using Domain.Interfaces;

namespace Domain.Base
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}