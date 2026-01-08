using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.GetAllOrders
{
    public class GetAllOrdersHandler
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<object>> Handle()
        {
            var orders = await _orderRepository.GetAllAsync();


            var result = orders.Select(order => new
            {
                order.Id,
                order.CustomerId,
                Status = order.Status.ToString(),
                Total = order.Total.Amount,
                order.CreatedAt,
                Items = order.Items.Select(i => new
                {
                    i.ProductId,
                    ProductName = i.Product.Name,
                    i.Quantity,
                    UnitPrice = i.UnitPrice.Amount,
                    Subtotal = i.SubTotal.Amount
                }).ToList()
            });

            return result;
        }
    }
}
