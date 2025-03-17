using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetUserQuery(int UserId) : IRequest<User?>;
