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

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class UpdateOrderConsumer : IConsumer<UpdatedOrderEvent>
    {
    
        private readonly IProductsService _productsService;

        public UpdateOrderConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {

            var productsInOrder = new List<ProductInOrder>();
            var products = new List<Product>();

            foreach (var product in productsInOrder)
            {
                products.Add(new Product
                {
                    Id = product.ProductId,
                    Quantity = product.OrderedQuantity
                });
            }

            foreach (var product in products)
            {
                _productsService.UpdateProduct(new Product { Id = product.Id, Quantity = product.Quantity});

            }

            return Task.CompletedTask;
        }
    }
}
