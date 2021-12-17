using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Models;
using MacNuget.Warehouse.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class NewRefillConsumer : IConsumer<NewRefillEvent>
    {

        private readonly IProductsService _productsService;

        public NewRefillConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public Task Consume(ConsumeContext<NewRefillEvent> context)
        {

            var product = context.Message.Product;


            var productToInsert = new Product
            {
                Id = product.Id,
                Quantity = product.Quantity,
            };

            _productsService.UpdateProduct(productToInsert);

            return Task.CompletedTask;
        }
    }
}
