using System;
using Domain.Base;

namespace Domain.Entities
{
    public class OrderItem : EntityBase
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public int Quantity { get; set; }
    }
}