using AutoMapper;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.Models;

namespace SmartExpenseControl.Application.Expenses.Profiles;

public sealed class ExpenseGroupProfile : Profile
{
    public ExpenseGroupProfile()
    {
        CreateMap<ExpenseGroup, ExpenseGroupSummary>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        CreateMap<CreateExpenseGroupCommand, ExpenseGroup>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
