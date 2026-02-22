using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PessoasApi.Application.Abstractions;
using PessoasApi.Application.People.Queries;
using PessoasApi.Domain.Repositories;
using PessoasApi.Infrastructure.Data;
using PessoasApi.Infrastructure.Repositories;

namespace PessoasApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? "Data Source=people.db";

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IQueryHandler<ListPeopleQuery, IReadOnlyList<PersonResponse>>, ListPeopleQueryHandler>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        await using var scope = serviceProvider.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.EnsureCreatedAsync();
    }
}
