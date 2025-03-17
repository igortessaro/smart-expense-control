using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class UpdateExpenseGroupValidator : AbstractValidator<UpdateExpenseGroupCommand>
{
    public UpdateExpenseGroupValidator()
    {

    }
}
