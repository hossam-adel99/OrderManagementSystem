using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.GetOrder
{
    public class GetOrderHandler
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Inner class for binding
        public class OrderBind
        {
            public Guid Id { get; set; }
            public string CustomerId { get; set; }
            public string Status { get; set; } = string.Empty;
            public decimal Total { get; set; }
            public DateTime CreatedAt { get; set; }
            public List<OrderItemBind> Items { get; set; } = new();
        }

        public class OrderItemBind
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Subtotal { get; set; }
        }

        public async Task<OrderBind?> Handle(GetOrderQuery query)
        {
            var order = await _orderRepository.GetByIdAsync(query.OrderId);

            if (order == null)
                return null;

            return MapToBind(order);
        }

        private OrderBind MapToBind(Order order)
        {
            return new OrderBind
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Status = order.Status.ToString(),
                Total = order.Total.Amount,
                CreatedAt = order.CreatedAt,
                Items = order.Items.Select(i => new OrderItemBind
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice.Amount,
                    Subtotal = i.SubTotal.Amount
                }).ToList()
            };
        }
    }

}
