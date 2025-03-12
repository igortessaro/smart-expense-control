using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}
