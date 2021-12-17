using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservices.Ecommerce.DTO.Events;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Models;
using MacNuget.Warehouse.Commands;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class NewProductConsumer : IConsumer<CreateProductCommand>
    {

        private readonly IProductsService _productsService;
        public NewProductConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public Task Consume(ConsumeContext<CreateProductCommand> context)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAA");
            var product = context.Message;

            var productToInsert = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity
            };

            _productsService.InsertProduct(productToInsert);

            return Task.CompletedTask;  
          
        }
    }
}
