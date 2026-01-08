using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.GetOrder
{
    public class GetOrderQuery
    {
        public Guid OrderId { get; set; }

        public GetOrderQuery() { }
        public GetOrderQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
