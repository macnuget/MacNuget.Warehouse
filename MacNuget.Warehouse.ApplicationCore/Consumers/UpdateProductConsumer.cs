using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Models;
using MassTransit;
using Gruppo4MicroserviziDTO.DTOs;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class UpdateProductConsumer : IConsumer<UpdatedOrderEvent>
    {
       
        public UpdateProductConsumer()
        {
        }

        private readonly IProductsService _productsService;

        public UpdateProductConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {
            
            var products = context.Message.Products;

            foreach (var product in products)
            {
                _productsService.UpdateProduct(new Product { Id = product.ProductId, Quantity = product.OrderedQuantity});

            }

            return Task.CompletedTask;
        }
    }
}
