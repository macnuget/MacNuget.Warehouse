﻿using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
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
    public class UpdateProductConsumer : IConsumer<UpdateProductEvent>
    {

        private readonly IProductsService _productsService;

        public UpdateProductConsumer(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public Task Consume(ConsumeContext<UpdateProductEvent> context)
        {

            var product = context.Message;

            var productToInsert = new Product
            {
                Id = product.Id,
                Name = product.Nome,

            };

            _productsService.UpdateProduct(productToInsert);

            return Task.CompletedTask;

        }
    }
}
