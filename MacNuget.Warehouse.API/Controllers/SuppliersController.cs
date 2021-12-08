using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
using MacNuget.Warehouse.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacNuget.Warehouse.API.Controllers
{

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
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
        {
            var items = _service.GetAllSuppliers().Select(x => new SupplierDto
            {
                Denomination = x.Denomination,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                VatNumber = x.VatNumber
            });

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetById(string id)
        {
            var supplier = _service.GetSupplier(id);

            return new SupplierDto
            {
                Denomination = supplier.Denomination,
                VatNumber = supplier.VatNumber,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<SupplierDto>> Create([FromBody] SupplierDto supplier)
        {
            var id = _service.InsertSupplier(new Supplier
            {
                Denomination = supplier.Denomination,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                VatNumber = supplier.VatNumber
            });

            return await GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierDto>> Update([FromBody] SupplierDto supplier, string id)
        {
            _service.UpdateSupplier(new Supplier
            {
                Denomination = supplier.Denomination,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                VatNumber = id
            });

            return await GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierDto>> Delete(string id)
        {
            var item = await GetById(id);
            _service.DeleteSupplier(id);
            return item;
        }
    }
}