using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseControl.Application.Commands.CreateUser;
using SmartExpenseControl.Application.Queries.GetUser;

namespace SmartExpenseControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var userId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUser), new { id = userId }, userId);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await mediator.Send(new GetUserQuery { UserId = id });
        return Ok(user);
    }
}