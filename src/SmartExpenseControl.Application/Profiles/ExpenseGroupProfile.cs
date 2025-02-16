using AutoMapper;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Profiles;

public sealed class ExpenseGroupProfile : Profile
{
    public ExpenseGroupProfile()
    {
        CreateMap<ExpenseGroupSummary, ExpenseGroup>().ReverseMap();
    }
}
