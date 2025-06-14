using Microsoft.Extensions.DependencyInjection;
using MRB.Domain.Abstractions;
using MRB.Infra.Data.Abstractions;
using MRB.Infra.Data.Implementations;

namespace MRB.Infra.IoC;

public static class RepositoryDependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDeliveryPersonRepository, DeliveryPersonRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddScoped<IMotorcycleCreatedRepository, MotorcycleCreatedRepository>();
        
        return services;
    }
}