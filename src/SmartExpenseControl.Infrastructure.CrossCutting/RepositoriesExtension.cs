using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Domain.ExpenseGroups.Repositories;
using SmartExpenseControl.Domain.Users.Repositories;
using SmartExpenseControl.Infrastructure.Data;
using SmartExpenseControl.Infrastructure.Repositories;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 21));
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        _ = services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, mySqlVersion));
        _ = services.AddScoped<IUserRepository, UserRepository>();
        _ = services.AddScoped<IExpenseRepository, ExpenseRepository>();
        _ = services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        _ = services.AddScoped<IExpenseGroupRepository, ExpenseGroupRepository>();
        return services;
    }
}
