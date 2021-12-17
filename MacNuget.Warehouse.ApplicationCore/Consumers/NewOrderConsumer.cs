using Gruppo4MicroserviziDTO.DTOs;
using Gruppo4MicroserviziDTO.Models;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Dto;
using MacNuget.Warehouse.Domain.Models;
using MassTransit;
using MacNuget.Warehouse.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Consumers
{
    public class NewOrderConsumer : IConsumer<CreateOrderCommand>
    {
       

        private readonly IProductsService _productsService;

        public NewOrderConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }


        public async Task Consume(ConsumeContext<CreateOrderCommand> context)
        {
            var product = new Product
            {
                Id = context.Message.ProductId,
                Quantity = context.Message.Quantity,
            };
        
            var p = await _productsService.GetProduct(product.Id);
            await _productsService.UpdateProduct(new Product { Id = p.Id, Quantity = (p.Quantity - product.Quantity) });
        }
    }
}
