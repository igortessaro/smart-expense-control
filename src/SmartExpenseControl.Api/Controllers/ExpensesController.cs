using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateExpense;
using SmartExpenseControl.Application.Queries.GetExpenses;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExpense(CreateExpenseCommand command)
    {
        var expenseId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetExpenses), new { id = expenseId }, expenseId);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetExpenses(int userId)
    {
        var expenses = await mediator.Send(new GetExpensesQuery { UserId = userId });
        return Ok(expenses);
    }
}