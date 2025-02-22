using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Application.Behaviors;
using SmartExpenseControl.Application.Commands.CreateUser;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class CqrsExtension
{
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
        _ = services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        _ = services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        return services;
    }
}
