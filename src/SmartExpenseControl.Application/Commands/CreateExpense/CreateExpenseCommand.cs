using MediatR;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public class CreateExpenseCommand : IRequest<int>
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
