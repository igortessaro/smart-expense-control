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
        var createdExpense = await mediator.Send(command);
        return Created($"api/Expenses/{createdExpense.Id}", createdExpense);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetExpenses(int userId)
    {
        var expenses = await mediator.Send(new GetExpensesQuery { UserId = userId });
        return Ok(expenses);
    }
}
