using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class DeleteProductConsumer : IConsumer<DeleteProductEvent>
    {
        public DeleteProductConsumer()
        {
        }

        private readonly IProductsService _productsService;

        public DeleteProductConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public Task Consume(ConsumeContext<DeleteProductEvent> context)
        {

            var id = context.Message.Id;

            _productsService.DeleteProduct(id);

            return Task.CompletedTask;
        }
    }
}
