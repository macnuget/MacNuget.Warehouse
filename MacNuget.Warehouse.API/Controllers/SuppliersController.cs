using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{
    public class Supplier
    {
        string TaxNumber;
        string PhoneNumber;
        string EmailAddress;
    }

    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {

        private readonly ILogger<SuppliersController> _logger;
        private readonly ISuppliersService _service;

        public SuppliersController(ILogger<SuppliersController> logger, ISuppliersService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetById(string id)
        {
            return new Supplier();
        }

        [HttpPost("")]
        public async Task<ActionResult<Supplier>> Create()
        {
            return StatusCode(501);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> Update()
        {
            return StatusCode(501);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplier>> Delete()
        {
            return StatusCode(501);
        }
    }
}