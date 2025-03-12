using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateExpenseGroup;
using SmartExpenseControl.Application.Commands.UpdateExpenseGroup;
using SmartExpenseControl.Application.Queries.GetExpenses;

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
    public Task<IActionResult> GetAsync([FromRoute] int id) => throw new NotImplementedException();

    [HttpGet]
    public Task<IActionResult> GetAllAsync() => throw new NotImplementedException();

    [HttpPost]
    public Task<IActionResult> CreateAsync([FromBody] CreateExpenseGroupCommand command) => throw new NotImplementedException();

    [HttpPut("{id:int}")]
    public Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateExpenseGroupCommand command) => throw new NotImplementedException();

    [HttpDelete("{id:int}")]
    public Task<IActionResult> DeleteAsync([FromRoute] int id) => throw new NotImplementedException();
}
