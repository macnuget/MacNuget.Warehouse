using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
using MacNuget.Warehouse.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _service;

        public ProductsController(ILogger<ProductsController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = _service.GetProduct(id);
            return new ProductDto()
            {
                Id = product.Id,
                Quantity = product.Quantity,
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto product)
        {
            return StatusCode(501);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto product, int id)
        {
            _service.UpdateProduct(new Product
            {
                Id=id,
                Quantity=product.Quantity
            });

            return await GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> Delete(int id)
        {
            return StatusCode(501);
        }
    }
}