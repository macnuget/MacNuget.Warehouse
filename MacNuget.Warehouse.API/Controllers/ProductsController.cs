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
            var items = _service.GetAllProducts().Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity
            });

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = _service.GetProduct(id);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto product)
        {
            var id = _service.InsertProduct(new Product
            {
                Name = product.Name,
                Quantity = product.Quantity
            });

            return await GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto product, int id)
        {
            _service.UpdateProduct(new Product
            {
                Id=id,
                Name = product.Name,
                Quantity=product.Quantity
            });

            return await GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> Delete(int id)
        {
            var item = await GetById(id);
            _service.DeleteProduct(id);
            return item;
        }
    }
}