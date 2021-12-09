using Gruppo4MicroserviziDTO.DTOs;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class NewOrderConsumer : IConsumer<NewOrderEvent>
    {
        public NewOrderConsumer()
        {
        }

        private readonly IProductsService _productsService;

        public NewOrderConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }


        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            var products = context.Message.Products;

            foreach (var product in products)
            {
                _productsService.UpdateProduct(new Product { Id = product.ProductId, Quantity = product.OrderedQuantity });

            }

            return Task.CompletedTask; 
        }
    }
}
