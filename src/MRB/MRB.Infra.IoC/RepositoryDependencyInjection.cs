using Microsoft.Extensions.DependencyInjection;
using MRB.Domain.Abstractions;
using MRB.Infra.Data.Implementations;

namespace MRB.Infra.IoC;

public static class RepositoryDependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IDeliveryPersonRepository, DeliveryPersonRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        
        return services;
    }
}