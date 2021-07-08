using System;
using System.Collections.Generic;
using BusinessLogic.Entities.Identity;
using Domain.Base;
using Domain.Enums;
using Domain.Interfaces;

namespace BusinessLogic.Entities
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