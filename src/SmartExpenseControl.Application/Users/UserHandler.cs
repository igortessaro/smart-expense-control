using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Application.Users.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Application.Users;

public sealed class UserHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper) :
    IRequestHandler<CreateUserCommand, Message<UserSummary>>,
    IRequestHandler<GetSingleUserQuery, Message<UserSummary>>,
    IRequestHandler<GetAllRolesQuery, Message<IList<UserRole>>>,
    IRequestHandler<UpdateUserCommand, Message<UserSummary>>,
    IRequestHandler<DeleteUserCommand, Message>,
    IRequestHandler<UpdatePasswordCommand, Message<UserSummary>>
{
    public async Task<Message<IList<UserRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) =>
        Message<IList<UserRole>>.Ok(await userRoleRepository.GetAllAsync());

    public async Task<Message<UserSummary>> Handle(GetSingleUserQuery request, CancellationToken cancellationToken) =>
        await userRepository.GetByIdAsync(request.Id);

    public async Task<Message<UserSummary>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userToAdd = mapper.Map<User>(request);
        var user = await userRepository.AddAsync(userToAdd);
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

    public async Task<Message<UserSummary>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var entity = await userRepository.GetAsync(request.Id);
        _ = entity!.UpdatePassword(request.NewPassword);
        return mapper.Map<UserSummary>(entity);
    }
}
