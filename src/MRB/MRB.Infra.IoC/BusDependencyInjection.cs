using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRB.Application.Abstractions;
using MRB.Bus.Consumers;
using MRB.Bus.Implementations;

namespace MRB.Infra.IoC;

public static class BusDependencyInjection
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEventPublisher, EventPublisher>();

        services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(MotorcycleCreatedConsumer).Assembly);

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], h =>
                {
                    h.Username(configuration["RabbitMq:Username"]);
                    h.Password(configuration["RabbitMq:Password"]);
                });

                cfg.ConfigureEndpoints(ctx);
            });
        });

        return services;
    }
}