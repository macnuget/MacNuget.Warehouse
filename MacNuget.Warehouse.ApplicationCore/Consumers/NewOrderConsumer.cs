using Gruppo4MicroserviziDTO.DTOs;
using Gruppo4MicroserviziDTO.Models;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
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
       

        private readonly IProductsService _productsService;

        public NewOrderConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }


        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            var productsInOrder = new List<ProductInOrder>();
            var products = new List<Product>();

            

            foreach (var product in productsInOrder)
            {
                products.Add(new Product
                {
                    Id = product.ProductId,
                    Quantity = product.OrderedQuantity,
                });
            }
            

            foreach (var product in products)
            {
                var p = _productsService.GetProduct(product.Id);
                _productsService.UpdateProduct(new Product { Id = product.Id, Quantity = (p.Quantity - product.Quantity) });
            }

            return Task.CompletedTask;
        }
    }
}
