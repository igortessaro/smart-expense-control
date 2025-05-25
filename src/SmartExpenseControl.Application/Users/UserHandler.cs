using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Application.Users.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Application.Users;

public sealed class UserHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper) :
    IRequestHandler<CreateUserCommand, Notification<UserSummary>>,
    IRequestHandler<GetSingleUserQuery, Notification<UserSummary>>,
    IRequestHandler<GetAllRolesQuery, Notification<IList<UserRole>>>,
    IRequestHandler<UpdateUserCommand, Notification<UserSummary>>,
    IRequestHandler<DeleteUserCommand, Notification>,
    IRequestHandler<UpdatePasswordCommand, Notification<UserSummary>>
{
    public async Task<Notification<IList<UserRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) =>
        Notification<IList<UserRole>>.Ok(await userRoleRepository.GetAllAsync());

    public async Task<Notification<UserSummary>> Handle(GetSingleUserQuery request, CancellationToken cancellationToken) =>
        await userRepository.GetByIdAsync(request.Id);

    public async Task<Notification<UserSummary>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userToAdd = mapper.Map<User>(request);
        var user = await userRepository.AddAsync(userToAdd);
        return mapper.Map<UserSummary>(user);
    }

    public async Task<Notification<UserSummary>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await userRepository.GetAsync(request.Id);
        _ = entity?.Update(request.Username, request.Email, request.RoleId);
        return mapper.Map<UserSummary>(await userRepository.UpdateAsync(entity!));
    }

    public async Task<Notification> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await userRepository.DeleteAsync(request.Id);
        return Notification.Ok();
    }

    public async Task<Notification<UserSummary>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var entity = await userRepository.GetAsync(request.Id);
        _ = entity!.UpdatePassword(request.NewPassword);
        return mapper.Map<UserSummary>(entity);
    }
}
