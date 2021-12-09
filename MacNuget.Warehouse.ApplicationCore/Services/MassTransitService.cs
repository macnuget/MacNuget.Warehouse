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

                    rabbitConfigurator.ReceiveEndpoint("new-quantity-event", e =>
                    {
                        e.Consumer<UpdateProductConsumer>();
                    });

                    rabbitConfigurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
