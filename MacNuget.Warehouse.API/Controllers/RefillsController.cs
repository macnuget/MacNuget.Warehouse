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

        private RefillDto ConvertToDTO(Refill refill)
        {
            return new RefillDto
            {
                Id = refill.Id,
                ArriveDate = refill.ArriveDate,
                ProductId = refill.ProductId,
                SupplierId = refill.SupplierId,
            };
        }

        private Refill ConvertToModel(RefillDto refill)
        {
            return ConvertToModel(refill, refill.Id);
        }

        private Refill ConvertToModel(RefillDto refill, int id)
        {
            return new Refill
            {
                Id = id,
                ArriveDate = refill.ArriveDate,
                ProductId = refill.ProductId,
                SupplierId = refill.SupplierId,
                Quantity = refill.Quantity
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefillDto>>> GetAll()
        {
            var items = (await _service.GetAllRefills()).Select(x => ConvertToDTO(x));

            return new JsonResult(items)
            {
                StatusCode = 200
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RefillDto>> GetById(int id)
        {
            var refill = ConvertToDTO(await _service.GetRefill(id));

            return new JsonResult(refill)
            {
                StatusCode = 200
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<RefillDto>> Create([FromBody] RefillDto refill)
        {

            var insertedRefill = await _service.InsertRefill(ConvertToModel(refill));

            var insertedRefillDto = ConvertToDTO(insertedRefill);

            return new JsonResult(insertedRefillDto)
            {
                StatusCode = 201
            };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RefillDto>> Update([FromBody] RefillDto refill, int id)
        {
            var updatedRefill = await _service.UpdateRefill(ConvertToModel(refill, id));

            var updatedRefillDto = ConvertToDTO(updatedRefill);

            return new JsonResult(updatedRefillDto)
            {
                StatusCode = 200
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RefillDto>> Delete(int id)
        {
            var deletedRefill = await _service.DeleteRefill(id);
            var deletedRefillDto = ConvertToDTO(deletedRefill);

            return new JsonResult(deletedRefillDto)
            {
                StatusCode = 200
            };
        }
    }
}