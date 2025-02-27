using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Api.Filters;

public sealed class NotificationFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var notification = context.Result as ObjectResult;
        if (notification?.Value is Message { IsFailed: true } message)
        {
            context.Result = new BadRequestObjectResult(message);
        }

        await next();
    }
}
