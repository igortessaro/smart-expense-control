using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Application.Expenses.Profiles;
using SmartExpenseControl.Application.Users.Profiles;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class MapperExtension
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        _ = services.AddAutoMapper(x => x.AddProfile<ExpenseProfile>());
        _ = services.AddAutoMapper(x => x.AddProfile<ExpenseGroupProfile>());
        _ = services.AddAutoMapper(x => x.AddProfile<UserProfile>());
        return services;
    }
}
