using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetUser;

public class GetUserQuery : IRequest<User?>
{
    public int UserId { get; init; }
}
