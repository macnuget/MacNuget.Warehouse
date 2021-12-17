using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Models;
using MassTransit;
using Gruppo4MicroserviziDTO.DTOs;
using Gruppo4MicroserviziDTO.Models;
using MacNuget.Warehouse.Commands;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class UpdateOrderConsumer : IConsumer<UpdateOrderCommand>
    {
    
        private readonly IProductsService _productsService;

        public UpdateOrderConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task Consume(ConsumeContext<UpdateOrderCommand> context)
        {
            var product = context.Message;

            var p = await _productsService.GetProduct(product.ProductId);
           
            await _productsService.UpdateProduct(new Product { Id = p.Id, Quantity = (p.Quantity - product.Quantity)});
        }
    }
}
