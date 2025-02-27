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
        var expense = response.GetData();
        return CreatedAtAction(nameof(GetAsync), new { id = expense?.Id }, response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id) => Ok(await mediator.Send(new GetSingleExpenseQuery(id)));
}
