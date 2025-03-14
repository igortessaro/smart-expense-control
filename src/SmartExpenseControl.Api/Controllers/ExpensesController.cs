using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Application.Expenses.Queries;
using System.Net.Mime;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateExpenseCommand command)
    {
        var response = await mediator.Send(command);
        return CreatedAtAction(nameof(GetAsync), new { id = response.Payload?.Id }, response);
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetAsync))]
    public async Task<IActionResult> GetAsync([FromRoute] int id) => Ok(await mediator.Send(new GetSingleExpenseQuery(id)));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateExpenseCommand command) => Ok(await mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public Task<IActionResult> DeleteAsync([FromRoute] int id) => throw new NotImplementedException();
}
