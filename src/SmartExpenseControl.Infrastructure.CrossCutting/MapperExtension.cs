using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Application.Profiles;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class MapperExtension
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        _ = services.AddAutoMapper(x => x.AddProfile<ExpenseProfile>());
        return services;
    }
}
