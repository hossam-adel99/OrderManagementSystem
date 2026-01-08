using OrderManagement.Domain.Entities.Exceptions;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class OrderItem
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        public Money UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        [NotMapped]
        public Money SubTotal => UnitPrice.Multiply(Quantity);

        // Navigation properties
        public Order Order { get; private set; }
        public Product Product { get; private set; } 

        private OrderItem() { }

        public OrderItem(Order order, Product product, int quantity)
        {
            if (order == null)
                throw new DomainException("Order cannot be null");

            if (product == null)
                throw new DomainException("Product cannot be null");

            if (quantity <= 0)
                throw new DomainException("Quantity must be greater than zero");

            if (order.Status == OrderStatus.Completed)
                throw new DomainException("Cannot add items to a completed order");


            OrderId = order.Id;
            Order = order;
            ProductId = product.Id;
            Product = product;
            Quantity = quantity;
            UnitPrice = product.Price;
        }

        internal void IncreaseQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new DomainException("Quantity must be greater than zero");

            Quantity += quantity;
        }
    }

}
