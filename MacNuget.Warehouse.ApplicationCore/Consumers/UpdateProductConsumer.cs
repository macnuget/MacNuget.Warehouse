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
        public Task Consume(ConsumeContext<UpdateProductCommand> context)
        {

            var product = context.Message;

            var productToInsert = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity == 0 ? _productsService.GetProduct(product.Id).Quantity: product.Quantity

            };

            _productsService.UpdateProduct(productToInsert);

            return Task.CompletedTask;

        }
    }
}
