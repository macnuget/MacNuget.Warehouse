using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
using MacNuget.Warehouse.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RefillsController : ControllerBase
    {

        private readonly ILogger<RefillsController> _logger;
        private readonly IRefillsService _service;

        public RefillsController(ILogger<RefillsController> logger, IRefillsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefillDto>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RefillDto>> GetById(int id)
        {
            var refill = _service.GetRefill(id);
            return new RefillDto()
            {
                Id = refill.Id,
                ArriveDate = refill.ArriveDate,
                ProductId = refill.ProductId,
                SupplierId = refill.SupplierId,
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<RefillDto>> Create([FromBody] RefillDto refill)
        {

            _service.InsertRefill(new Refill
            {
                Quantity = refill.Quantity
            });

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RefillDto>> Update([FromBody] RefillDto refill, int id)
        {
            return StatusCode(501);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RefillDto>> Delete(int id)
        {
            return StatusCode(501);
        }
    }
}