using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{
    public class Product
    {
        int Id;
        string Name;
        int Quantity;
    }

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return StatusCode(501);
        }

        [HttpPost("")]
        public async Task<ActionResult<Product>> Create()
        {
            return StatusCode(501);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update()
        {
            return StatusCode(501);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete()
        {
            return StatusCode(501);
        }
    }
}