using System;
using System.Collections.Generic;
using Domain.Base;
using Domain.Entities.Identity;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Order : EntityBase, IEntityUser<User>
    {
        public Guid AuthorId { get; set; }
        public User? Author { get; set; }

        public Guid DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = default!;

        public ICollection<OrderItem>? Items { get; set; }
    }
}