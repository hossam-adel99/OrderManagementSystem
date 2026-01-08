using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orders.AddItem;
using OrderManagement.Application.Orders.CompleteOrder;
using OrderManagement.Application.Orders.CreateOrder;
using OrderManagement.Application.Orders.GetAllOrders;
using OrderManagement.Application.Orders.GetOrder;
using OrderManagement.Domain.Entities;
namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly CreateOrderHandler _createOrder;
        private readonly AddItemHandler _addItem;
        private readonly CompleteOrderHandler _completeOrder;
        private readonly GetOrderHandler _getOrder;
        private readonly GetAllOrdersHandler _getAllOrders;

        public OrdersController(
            CreateOrderHandler createOrder,
            AddItemHandler addItem,
            CompleteOrderHandler completeOrder,
            GetOrderHandler getOrder,
            GetAllOrdersHandler getAllOrders)
        {
            _createOrder = createOrder;
            _addItem = addItem;
            _completeOrder = completeOrder;
            _getOrder = getOrder;
            _getAllOrders = getAllOrders;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var orderId = await _createOrder.Handle(command);
            return Ok(orderId);
        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItem(AddItemCommand command)
        {
            await _addItem.Handle(command);
            return Ok();
        }

        [HttpPost("{orderId}/complete")]
        public async Task<IActionResult> CompleteOrder(Guid orderId)
        {
            var command = new CompleteOrderCommand(orderId);
            await _completeOrder.Handle(command);
            return Ok();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var query = new GetOrderQuery(orderId);
            var order = await _getOrder.Handle(query);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _getAllOrders.Handle();
            return Ok(orders);
        }
    }
}
