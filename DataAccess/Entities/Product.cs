using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DataAccess.Entities
{
    public class Product : EntityBase
    {
        [MaxLength(64)] public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public Guid ThumbnailId { get; set; }
        public Image? Thumbnail { get; set; }

        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}