using Gruppo4MicroserviziDTO.DTOs;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Commands;
using MacNuget.Warehouse.Domain.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{

    public class DeleteOrderConsumer : IConsumer<DeleteOrderCommand>
    {

        private readonly IProductsService _productsService;

        public DeleteOrderConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task Consume(ConsumeContext<DeleteOrderCommand> context)
        {
            var product = context.Message;

            var p = await _productsService.GetProduct(context.Message.ProductId);

            await _productsService.UpdateProduct(new Product { Id = p.Id, Quantity = (p.Quantity + product.Quantity) });
        }
    }
}
