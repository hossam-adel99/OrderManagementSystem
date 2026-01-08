using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.AddItem
{
    public class AddItemHandler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public AddItemHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task Handle(AddItemCommand command)
        {
            Order order = await _orderRepository.GetByIdAsync(command.OrderId)
                ?? throw new ApplicationException("Order not found");

            Product product = await _productRepository.GetByIdAsync(command.ProductId)
                ?? throw new ApplicationException("Product not found");

            order.AddItem(product, command.Quantity);
            await _orderRepository.SaveAsync();
        }
    }

}
