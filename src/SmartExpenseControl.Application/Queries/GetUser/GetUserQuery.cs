using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetUser;

public class GetUserQuery(int userId) : IRequest<User?>
{
    public int UserId { get; } = userId;
}
