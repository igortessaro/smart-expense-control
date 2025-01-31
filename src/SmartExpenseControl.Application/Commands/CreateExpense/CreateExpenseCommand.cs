using MediatR;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public record CreateExpenseCommand : IRequest<int>
{
    public int UserId { get; init; }
    public int CategoryId { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime Date { get; init; }
}
