using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
using MacNuget.Warehouse.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        private ProductDto ConvertToDTO(Product product) {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }

        private Product ConvertToModel(ProductDto product)
        {
            return ConvertToModel(product, product.Id);
        }

        private Product ConvertToModel(ProductDto product, int id)
        {
            return new Product
            {
                Id = id,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var items = (await _service.GetAllProducts()).Select(x => ConvertToDTO(x));

            return new JsonResult(items)
            {
                StatusCode = 200
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = ConvertToDTO(await _service.GetProduct(id));

            return new JsonResult(product)
            {
                StatusCode = 200
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto product)
        {
            var insertedProduct = await _service.InsertProduct(ConvertToModel(product));

            var insertedProductDto = ConvertToDTO(insertedProduct);

            return new JsonResult(insertedProductDto)
            {
                StatusCode = 201
            };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto product, int id)
        {
            var updatedProduct = await _service.UpdateProduct(ConvertToModel(product, id));
            var updatedProductDto = ConvertToDTO(updatedProduct);


            return new JsonResult(updatedProductDto)
            {
                StatusCode = 200
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> Delete(int id)
        {
            var deletedProduct = await _service.DeleteProduct(id);
            var deletedProductDto = ConvertToDTO(deletedProduct);

            return new JsonResult(deletedProductDto)
            {
                StatusCode = 200
            };
        }
    }
}