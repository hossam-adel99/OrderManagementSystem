using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.CompleteOrder
{
    public class CompleteOrderCommand
    {
        public Guid OrderId { get; set; }

        public CompleteOrderCommand() { }
        public CompleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
