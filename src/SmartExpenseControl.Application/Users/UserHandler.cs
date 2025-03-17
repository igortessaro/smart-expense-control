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
    IRequestHandler<GetAllRolesQuery, Message<IList<UserRole>>>,
    IRequestHandler<UpdateUserCommand, Message<UserSummary>>,
    IRequestHandler<DeleteUserCommand, Message>
{
    public async Task<Message<IList<UserRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) =>
        Message<IList<UserRole>>.Ok(await userRoleRepository.GetAllAsync());

    public async Task<Message<UserSummary>> Handle(GetSingleUserQuery request, CancellationToken cancellationToken) =>
        await userRepository.GetByIdAsync(request.Id);

    public async Task<Message<UserSummary>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.AddAsync(mapper.Map<User>(request));
        return mapper.Map<UserSummary>(user);
    }

    public async Task<Message<UserSummary>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await userRepository.GetAsync(request.Id);
        _ = entity?.Update(request.Username, request.Email, request.RoleId);
        return mapper.Map<UserSummary>(await userRepository.UpdateAsync(entity!));
    }

    public async Task<Message> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await userRepository.DeleteAsync(request.Id);
        return Message.Ok();
    }

    private string HashPassword(string password)
    {
        // Implement password hashing logic here
        return password; // Placeholder
    }
}
