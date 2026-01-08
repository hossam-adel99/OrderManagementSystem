using OrderManagement.Domain.Entities.Exceptions;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        // Navigation property
        public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();


        private Order() { }
        public Order(string custmerId)
        {
            Id = Guid.NewGuid();
            CustomerId = custmerId;
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Pending;
        }

        public void AddItem(Product product, int quantity)
        {
            EnsureEditable();
            if (quantity <= 0)
                throw new DomainException("Quantity must be greater than zero");

            OrderItem existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
                return;
            }

            Items.Add(new OrderItem(this, product, quantity));
        }

        public void RemoveItem(Guid productId)
        {
            EnsureEditable();

            OrderItem item = Items.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
                throw new DomainException("Item not found in order");

            Items.Remove(item);
        }

        public void Complete()
        {
            if (Status == OrderStatus.Completed)
                throw new DomainException("Order is already completed");

            if (!Items.Any())
                throw new DomainException("Cannot complete empty order");

            Status = OrderStatus.Completed;
        }
        private void EnsureEditable()
        {
            if (Status == OrderStatus.Completed)
                throw new DomainException("Cannot modify completed order");
        }

        [NotMapped]
        public Money Total
        {
            get
            {
                decimal totalAmount = 0;
                foreach (var item in Items)
                {
                    totalAmount += item.SubTotal.Amount;
                }
                return new Money(totalAmount);
            }
        }
    }


}
