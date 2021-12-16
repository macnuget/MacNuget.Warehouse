using MacNuget.Warehouse.ApplicationCore.Consumers;
using MacNuget.Warehouse.Events;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.ApplicationCore.Services
{
    public static class MassTransitService
    {
        public static IServiceCollection AddMassTransitService(this IServiceCollection services)
        {
            services.AddMassTransit(o =>
            {
                o.AddConsumer<NewProductConsumer>();
                o.AddConsumer<NewOrderConsumer>();
                o.AddConsumer<UpdateOrderConsumer>();
                o.AddConsumer<UpdateProductConsumer>();
                o.AddConsumer<DeleteProductConsumer>();
                o.AddConsumer<DeleteOrderConsumer>();

                o.UsingRabbitMq((context, rabbitConfigurator) =>
                {
                    rabbitConfigurator.Host(
                        "roedeer.rmq.cloudamqp.com",
                        "vpeeygzh",
                        credentials =>
                        {
                            credentials.Username("vpeeygzh");
                            credentials.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                        }
                    );

                    rabbitConfigurator.ReceiveEndpoint("gruppo1-update-product-event", e =>
                    {
                        e.Consumer<UpdateProductConsumer>(context);
                    });

                    rabbitConfigurator.ReceiveEndpoint("gruppo1-new-product-event", e =>
                    {
                        e.Consumer<NewProductConsumer>(context);
                    });

                    rabbitConfigurator.ReceiveEndpoint("gruppo1-delete-product-event", e =>
                    {
                        e.Consumer<DeleteProductConsumer>(context);
                    });

                    rabbitConfigurator.ReceiveEndpoint("gruppo1-update-order-event", e =>
                    {
                        e.Consumer<UpdateOrderConsumer>(context);
                    });

                    rabbitConfigurator.ReceiveEndpoint("gruppo1-new-order-event", e =>
                    {
                        e.Consumer<NewOrderConsumer>(context);
                    });

                    rabbitConfigurator.ReceiveEndpoint("gruppo1-delete-order-event", e =>
                    {
                        e.Consumer<DeleteOrderConsumer>(context);
                    });

                    rabbitConfigurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
