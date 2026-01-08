using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Products.GetAllProducts
{
    public class GetAllProductsHandler
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<object>> Handle(GetAllProductsQuery query)
        {
            var products = await _productRepository.GetAllAsync();

            var result = products.Select(p => new
            {
                p.Id,
                p.Name,
                Price = p.Price.Amount,
                p.Description
            });

            return result;
        }
    }
}
