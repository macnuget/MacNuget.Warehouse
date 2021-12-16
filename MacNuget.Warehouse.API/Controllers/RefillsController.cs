using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
using MacNuget.Warehouse.Domain.Models;
using MacNuget.Warehouse.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RefillsController : ControllerBase
    {

        private readonly ILogger<RefillsController> _logger;
        private readonly IRefillsService _service;
        private readonly IProductsService _productsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public RefillsController(ILogger<RefillsController> logger, IRefillsService service, IPublishEndpoint publishEndpoint, IProductsService productsService)
        {
            _logger = logger;
            _service = service;
            _publishEndpoint = publishEndpoint;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefillDto>>> GetAll()
        {
            var items = _service.GetAllRefills().Select(x => new RefillDto
            {
                ArriveDate = x.ArriveDate,
                Id = x.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity
            });

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RefillDto>> GetById(int id)
        {
            var refill = _service.GetRefill(id);
            return new RefillDto
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

            var id = _service.InsertRefill(new Refill
            {
                SupplierId = refill.SupplierId,
                ArriveDate = refill.ArriveDate,
                ProductId = refill.ProductId,
                Quantity = refill.Quantity
            });

            
            var refillEvent = new NewRefillEvent();
            var product = new ProductForRefillEvent
            {
                Id = (int)refill.ProductId,
                Quantity = refill.Quantity
            };

            refillEvent.Product = product;

            await _publishEndpoint.Publish(refillEvent);

            _productsService.UpdateProduct(new Product { Id = (int)refill.ProductId, Quantity = refill.Quantity });

            return await GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RefillDto>> Update([FromBody] RefillDto refill, int id)
        {
            _service.UpdateRefill(new Refill
            {
                Id = id,
                ArriveDate = refill.ArriveDate,
                Quantity = refill.Quantity
            });

            return await GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RefillDto>> Delete(int id)
        {
            var item = await GetById(id);
            _service.DeleteRefill(id);
            return item;
        }
    }
}