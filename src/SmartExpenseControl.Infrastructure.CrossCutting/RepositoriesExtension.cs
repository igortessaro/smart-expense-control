using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;
using SmartExpenseControl.Infrastructure.Repositories;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21))));
        _ = services.AddScoped<IUserRepository, UserRepository>();
        _ = services.AddScoped<IExpenseRepository, ExpenseRepository>();
        return services;
    }
}