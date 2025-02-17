using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateExpense;
using SmartExpenseControl.Application.Queries.GetExpenses;
using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExpenseAsync(CreateExpenseCommand command)
    {
        var response = await mediator.Send(command);
        var expense = (ExpenseSummary?)response.Data;
        return Created($"api/Expenses/{expense?.Id}", response);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetExpensesAsync(int userId)
    {
        var expenses = await mediator.Send(new GetExpensesQuery { UserId = userId });
        return Ok(await Task.FromResult(expenses));
    }
}
