using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public class CreateExpenseCommandHandler(IExpenseRepository expenseRepository) : IRequestHandler<CreateExpenseCommand, int>
{
    public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = new Expense(request.UserId, request.CategoryId, request.Amount, request.Description, request.Date);
        await expenseRepository.AddAsync(expense);
        return expense.Id;
    }
}
