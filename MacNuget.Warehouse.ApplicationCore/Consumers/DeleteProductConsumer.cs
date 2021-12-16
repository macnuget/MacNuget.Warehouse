using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Commands;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class DeleteProductConsumer : IConsumer<DeleteProductCommand>
    { 

        private readonly IProductsService _productsService;

        public DeleteProductConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public Task Consume(ConsumeContext<DeleteProductCommand> context)
        {

            var id = context.Message.Id;

            _productsService.DeleteProduct(id);

            return Task.CompletedTask;
        }
    }
}
