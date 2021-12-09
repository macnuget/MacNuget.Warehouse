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

        private SupplierDto ConvertToDTO(Supplier supplier)
        {
            return new SupplierDto
            {
                Denomination = supplier.Denomination,
                VatNumber = supplier.VatNumber,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email
            };
        }

        private Supplier ConvertToModel(SupplierDto supplier)
        {
            return new Supplier
            {
                Denomination = supplier.Denomination,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                VatNumber = supplier.VatNumber
            };
        }

        private Supplier ConvertToModel(SupplierDto supplier, string id)
        {
            return new Supplier
            {
                Denomination = supplier.Denomination,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                VatNumber = id
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
        {
            var items = (await _service.GetAllSuppliers()).Select(x => ConvertToDTO(x));

            return new JsonResult(items)
            {
                StatusCode = 200
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetById(string id)
        {
            var supplier = ConvertToDTO(await _service.GetSupplier(id));

            return new JsonResult(supplier)
            {
                StatusCode = 200
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<SupplierDto>> Create([FromBody] SupplierDto supplier)
        {
            var insertedSupplier = await _service.InsertSupplier(ConvertToModel(supplier));

            var insertedSupplierDto = ConvertToDTO(insertedSupplier);

            return new JsonResult(insertedSupplierDto)
            {
                StatusCode = 201
            };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierDto>> Update([FromBody] SupplierDto supplier, string id)
        {
            var updatedSupplier = await _service.UpdateSupplier(ConvertToModel(supplier, id));

            var updatedSupplierDto = ConvertToDTO(updatedSupplier);

            return new JsonResult(updatedSupplierDto)
            {
                StatusCode = 200
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierDto>> Delete(string id)
        {
            var deletedSupplier = await _service.DeleteSupplier(id);
            var deletedRefillDto = ConvertToDTO(deletedSupplier);

            return new JsonResult(deletedRefillDto)
            {
                StatusCode = 200
            };
        }
    }
}