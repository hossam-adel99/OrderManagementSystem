
using global::OrderManagement.Application.Interfaces;
using global::OrderManagement.Application.Orders.CreateOrder;
using global::OrderManagement.Domain.Entities;
using Moq;


namespace OrderManagement.Tests.Orders
{
    public class CreateOrderHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_Order_And_Return_Id()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();

            repoMock
                .Setup(r => r.AddAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            repoMock
                .Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            var handler = new CreateOrderHandler(repoMock.Object);

            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid()
            };

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.NotEqual(Guid.Empty, result);

            repoMock.Verify(r => r.AddAsync(It.IsAny<Order>()), Times.Once);
            repoMock.Verify(r => r.SaveAsync(), Times.Once);
        }
    }
}
