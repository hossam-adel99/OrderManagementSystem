using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.CreateOrder
{
    public class CreateOrderHandler
    {
        private readonly IOrderRepository _orderRepo;

        public CreateOrderHandler(IOrderRepository repository)
        {
            _orderRepo = repository;
        }

        public async Task<Guid> Handle(CreateOrderCommand command)
        {
            var order =new Order(command.CustomerId.ToString());
            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveAsync();
            return order.Id;
        }
    }
}
