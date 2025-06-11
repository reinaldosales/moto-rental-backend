using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRB.Application.Abstractions;
using MRB.Application.Implementations;

namespace MRB.Infra.IoC;

public static class ServiceDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDeliveryPersonService, DeliveryPersonService>();
        services.AddScoped<IMotorcycleService, MotorcycleService>();
        services.AddScoped<IRentalService, RentalService>();
        
        return services;
    }
}