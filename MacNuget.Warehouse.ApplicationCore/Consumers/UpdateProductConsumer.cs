using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Commands;
using MacNuget.Warehouse.Domain.Models;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class UpdateProductConsumer : IConsumer<UpdateProductCommand>
    {

        private readonly IProductsService _productsService;

        public UpdateProductConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task Consume(ConsumeContext<UpdateProductCommand> context)
        {
            var product = context.Message;
            
            var p = await _productsService.GetProduct(product.Id);

            await _productsService.UpdateProduct(new Product { Id = p.Id, Name = product.Name, Quantity = (p.Quantity + product.Quantity) });
        }
    }
}
