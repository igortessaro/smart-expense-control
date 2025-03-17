using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.DeleteExpenseGroup;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Application.Expenses.Queries;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ExpenseGroupsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:int}/expenses/{period}")]
    public async Task<IActionResult> GetExpensesAsync(
        [FromRoute] int id,
        [FromRoute] string period,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize) =>
        Ok(await mediator.Send(new GetExpensesByGroupQuery(id, period, pageNumber ?? 1, pageSize ?? 10)));

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetAsync))]
    public async Task<IActionResult> GetAsync([FromRoute] int id) => Ok(await mediator.Send(new GetSingleExpenseGroupQuery(id)));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int? pageNumber, [FromQuery] int? pageSize) =>
        Ok(await mediator.Send(new GetExpenseGroupsQuery(pageNumber ?? 1, pageSize ?? 10)));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateExpenseGroupCommand command)
    {
        var response = await mediator.Send(command);
        return CreatedAtAction(nameof(GetAsync), new { id = response.Payload?.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateExpenseGroupCommand command) => Ok(await mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id) => Ok(await mediator.Send(new DeleteExpenseGroupCommand(id)));
}
