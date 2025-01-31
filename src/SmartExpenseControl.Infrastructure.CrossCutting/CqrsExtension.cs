using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Application.Commands.CreateUser;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class CqrsExtension
{
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
        return services;
    }
}