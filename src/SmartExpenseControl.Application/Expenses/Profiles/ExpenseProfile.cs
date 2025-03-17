using AutoMapper;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Expenses.Profiles;

public sealed class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>().ReverseMap();
        CreateMap<Expense, ExpenseSummary>().ReverseMap();
        CreateMap<UpdateExpenseCommand, Expense>().ReverseMap();
    }
}
