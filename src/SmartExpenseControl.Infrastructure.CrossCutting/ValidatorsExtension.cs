using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenseControl.Application.Commands.CreateExpense;

namespace SmartExpenseControl.Infrastructure.CrossCutting;

public static class ValidatorsExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        _ = services.AddValidatorsFromAssemblyContaining<CreateExpenseValidator>();
        return services;
    }
}
