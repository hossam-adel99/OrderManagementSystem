using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Products.GetProduct
{
    public class GetProductHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<object?> Handle(GetProductQuery query)
        {
            var product = await _productRepository.GetByIdAsync(query.ProductId);

            if (product == null)
                return null;


            var result = new
            {
                product.Id,
                product.Name,
                Price = product.Price.Amount,
                product.Description
            };

            return result;
        }
    }
}
