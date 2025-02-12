using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateUser;
using SmartExpenseControl.Application.Queries.GetRoles;
using SmartExpenseControl.Application.Queries.GetUser;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserCommand command)
    {
        var userId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUserAsync), new { id = userId }, userId);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var user = await mediator.Send(new GetUserQuery { UserId = id });
        return Ok(user);
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync()
    {
        var roles = await mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }
}
