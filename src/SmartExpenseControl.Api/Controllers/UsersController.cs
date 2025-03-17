using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Expenses.Queries;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Application.Users.Queries;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:int}/expenses/{period}")]
    public async Task<IActionResult> GetExpensesAsync(
        [FromRoute] int id,
        [FromRoute] string period,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize) =>
        Ok(await mediator.Send(new GetExpensesQuery(id, period, pageNumber ?? 1, pageSize ?? 10)));

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetAsync))]
    public async Task<IActionResult> GetAsync([FromRoute] int id) => Ok(await mediator.Send(new GetUserQuery(id)));

    [Obsolete]
    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync() => Ok(await mediator.Send(new GetAllRolesQuery()));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
    {
        var response = await mediator.Send(command);
        return CreatedAtAction(nameof(GetAsync), new { id = response.Payload?.Id }, response);
    }

    [HttpPut("{id:int}")]
    public Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateUserCommand command) => throw new NotImplementedException();

    [HttpPatch("{id:int}/password")]
    public Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] UpdatePasswordCommand command) => throw new NotImplementedException();

    [HttpDelete("{id:int}")]
    public Task<IActionResult> DeleteAsync([FromRoute] int id) => throw new NotImplementedException();
}
