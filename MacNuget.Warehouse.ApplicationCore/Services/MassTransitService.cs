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
                o.UsingRabbitMq((context, rabbitConfigurator) =>
                {
                    rabbitConfigurator.Host(
                        "localhost",
                        "/",
                        credentials =>
                        {
                            credentials.Username("admin");
                            credentials.Password("password");
                        }
                    );

                    rabbitConfigurator.ReceiveEndpoint("update-product-event", e =>
                    {
                        e.Consumer<UpdateProductConsumer>();
                    });

                    rabbitConfigurator.ReceiveEndpoint("new-product-event", e =>
                    {
                        e.Consumer<NewProductConsumer>();
                    });

                    rabbitConfigurator.ReceiveEndpoint("delete-product-event", e =>
                    {
                        e.Consumer<DeleteProductConsumer>();
                    });

                    rabbitConfigurator.ReceiveEndpoint("update-order-event", e =>
                    {
                        e.Consumer<UpdateOrderConsumer>();
                    });

                    rabbitConfigurator.ReceiveEndpoint("new-order-event", e =>
                    {
                        e.Consumer<NewOrderConsumer>();
                    });

                    rabbitConfigurator.ReceiveEndpoint("delete-order-event", e =>
                    {
                        e.Consumer<DeleteOrderConsumer>();
                    });

                    rabbitConfigurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
