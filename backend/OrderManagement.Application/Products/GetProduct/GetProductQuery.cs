using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Products.GetProduct
{
    public class GetProductQuery
    {
        public Guid ProductId { get; }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
