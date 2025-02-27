using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateExpense;
using SmartExpenseControl.Application.Queries.GetExpenses;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExpenseAsync(CreateExpenseCommand command)
    {
        Message<ExpenseSummary> response = await mediator.Send(command);
        ExpenseSummary? expense = response.Payload;
        return CreatedAtAction(nameof(GetAsync), new { id = expense?.Id }, response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id) => Ok(await mediator.Send(new GetSingleExpenseQuery(id)));
}
