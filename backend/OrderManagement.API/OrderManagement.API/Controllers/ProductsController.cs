using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Products.GetProduct;
using OrderManagement.Application.Products.GetAllProducts;
using System;
using System.Threading.Tasks;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductHandler _getProductHandler;
        private readonly GetAllProductsHandler _getAllProductsHandler;

        public ProductsController(
            GetProductHandler getProductHandler,
            GetAllProductsHandler getAllProductsHandler)
        {
            _getProductHandler = getProductHandler;
            _getAllProductsHandler = getAllProductsHandler;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var products = await _getAllProductsHandler.Handle(query);
            return Ok(products);
        }

        // GET api/products/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProductQuery(id);
            var product = await _getProductHandler.Handle(query);

            if (product == null)
                return NotFound($"Product with Id {id} not found");

            return Ok(product);
        }
    }
}
