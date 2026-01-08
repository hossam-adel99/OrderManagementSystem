using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.CompleteOrder
{
    public class CompleteOrderHandler
    {
        private readonly IOrderRepository _orderRepository;

        public CompleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CompleteOrderCommand command)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (order == null)
                throw new ApplicationException($"Order {command.OrderId} not found");

            order.Complete();

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }
    }

}
