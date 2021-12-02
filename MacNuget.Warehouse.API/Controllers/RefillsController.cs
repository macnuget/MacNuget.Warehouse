using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{
    public class Refill
    {
        int Id;
        int ProductId;
        string RefillTaxNumber;
        DateTime Date;
        int Quantity;
    }

    [ApiController]
    [Route("[controller]")]
    public class RefillsController : ControllerBase
    {

        private readonly ILogger<RefillsController> _logger;

        public RefillsController(ILogger<RefillsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refill>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Refill>> GetById(string id)
        {
            return StatusCode(501);
        }

        [HttpPost("")]
        public async Task<ActionResult<Refill>> Create()
        {
            return StatusCode(501);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Refill>> Update()
        {
            return StatusCode(501);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Refill>> Delete()
        {
            return StatusCode(501);
        }
    }
}