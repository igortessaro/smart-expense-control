using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Application.Users.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users;

public sealed class UserHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper) :
    IRequestHandler<CreateUserCommand, Message<UserSummary>>,
    IRequestHandler<GetSingleUserQuery, Message<UserSummary>>,
    IRequestHandler<GetAllRolesQuery, IList<UserRole>>
{
    public Task<IList<UserRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) => userRoleRepository.GetAllAsync();

    public async Task<Message<UserSummary>> Handle(GetSingleUserQuery request, CancellationToken cancellationToken) => await userRepository.GetByIdAsync(request.Id);

    public async Task<Message<UserSummary>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.AddAsync(new User(request.Username, request.Email, HashPassword(request.Password), request.RoleId));
        return mapper.Map<UserSummary>(user);
    }

    private string HashPassword(string password)
    {
        // Implement password hashing logic here
        return password; // Placeholder
    }
}
