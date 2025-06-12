using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRB.Infra.Data.Contexts;

namespace MRB.Infra.IoC;

public static class InfraestructureDependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "public");
            })
            .UseSnakeCaseNamingConvention();
        });
        
        return services;
    } 
}