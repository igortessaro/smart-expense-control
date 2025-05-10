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
    [HttpGet("{id:int}/expenses")]
    public async Task<IActionResult> GetExpensesAsync(
        [FromRoute] int id,
        [FromQuery] int? periodExpenseId,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize) =>
        Ok(await mediator.Send(new GetExpensesQuery(id, periodExpenseId, pageNumber ?? 1, pageSize ?? 10)));

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetAsync))]
    public async Task<IActionResult> GetAsync([FromRoute] int id) => Ok(await mediator.Send(new GetSingleUserQuery(id)));

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
    public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateUserCommand command) => Ok(await mediator.Send(command with { Id = id }));

    [HttpPatch("{id:int}/password")]
    public async Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] UpdatePasswordCommand command) => Ok(await mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id) => Ok(await mediator.Send(new DeleteUserCommand(id)));
}
