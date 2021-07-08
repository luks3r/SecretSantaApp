using System;
using System.Collections.Generic;
using Domain.Base;
using Domain.Enums;

namespace DataAccess.Entities
{
    public class Discount : EntityBase
    {
        public DiscountType Type { get; set; }
        public string Code { get; set; } = default!;
        public decimal Amount { get; set; }

        public DateTime From { get; set; }
        public DateTime Until { get; set; }

        public ICollection<Product>? RequiredProducts { get; set; }
        public ICollection<Product>? ProductsToApply { get; set; }
    }
}