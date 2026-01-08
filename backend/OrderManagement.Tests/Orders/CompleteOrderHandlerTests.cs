using Moq;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Orders.CompleteOrder;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Entities.Exceptions;
using OrderManagement.Domain.Enums;


namespace OrderManagement.Tests.Orders
{

    public class CompleteOrderHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Complete_Order_Successfully()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var order = new Order("cust-1");

            order.AddItem(
                new Product("Burger", new Domain.ValueObjects.Money(100)),
                2
            );

            var repoMock = new Mock<IOrderRepository>();

            repoMock
                .Setup(r => r.GetByIdAsync(orderId))
                .ReturnsAsync(order);

            var handler = new CompleteOrderHandler(repoMock.Object);

            var command = new CompleteOrderCommand
            {
                OrderId = orderId
            };

            // Act
            await handler.Handle(command);

            // Assert
            Assert.Equal(OrderStatus.Completed, order.Status);

            repoMock.Verify(r => r.UpdateAsync(order), Times.Once);
            repoMock.Verify(r => r.SaveAsync(), Times.Once);
        }



        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Order_Not_Found()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();

            repoMock
                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Order)null);

            var handler = new CompleteOrderHandler(repoMock.Object);

            var command = new CompleteOrderCommand
            {
                OrderId = Guid.NewGuid()
            };

            // Act & Assert
            await Assert.ThrowsAsync<ApplicationException>(() =>
                handler.Handle(command)
            );
        }


        [Fact]
        public async Task Handle_Should_Throw_DomainException_When_Order_Already_Completed()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var order = new Order("cust-1");

            order.AddItem(
                new Product("Burger", new Domain.ValueObjects.Money(100)),
                1
            );

            order.Complete();

            var repoMock = new Mock<IOrderRepository>();

            repoMock
                .Setup(r => r.GetByIdAsync(orderId))
                .ReturnsAsync(order);

            var handler = new CompleteOrderHandler(repoMock.Object);

            var command = new CompleteOrderCommand
            {
                OrderId = orderId
            };

            // Act & Assert
            await Assert.ThrowsAsync<DomainException>(() =>
                handler.Handle(command)
            );
        }

    }
}
