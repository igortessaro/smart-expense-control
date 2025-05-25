using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Domain.ExpenseGroups.Services;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IExpenseService, ExpenseService>();
        _ = services.AddScoped<IExpenseGroupService, ExpenseGroupService>();
        return services;
    }
}
