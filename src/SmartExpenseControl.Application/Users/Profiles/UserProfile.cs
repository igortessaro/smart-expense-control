using AutoMapper;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Application.Users.Profiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserSummary>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
            .ReverseMap()
            .ForMember(dest => dest.Role, opt => opt.Ignore());
        CreateMap<CreateUserCommand, User>().ConstructUsing(dest => new User(dest.Username, dest.Email, dest.RoleId).UpdatePassword(dest.Password));
        CreateMap<UpdatePasswordCommand, User>().ReverseMap();
        CreateMap<UpdateUserCommand, User>().ReverseMap();
    }
}
