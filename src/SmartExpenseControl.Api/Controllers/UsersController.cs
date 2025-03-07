using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateUser;
using SmartExpenseControl.Application.Queries.GetExpenses;
using SmartExpenseControl.Application.Queries.GetRoles;
using SmartExpenseControl.Application.Queries.GetUser;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userId:int}/expenses")]
    public async Task<IActionResult> GetExpensesAsync(
        [FromRoute] int userId,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize) =>
        Ok(await mediator.Send(new GetExpensesQuery(userId, pageNumber ?? 1, pageSize ?? 10)));

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserCommand command)
    {
        Message<User> response = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUserAsync), new { id = response.Payload?.Id }, response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserAsync(int id) => Ok(await mediator.Send(new GetUserQuery(id)));

    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync() => Ok(await mediator.Send(new GetAllRolesQuery()));
}
