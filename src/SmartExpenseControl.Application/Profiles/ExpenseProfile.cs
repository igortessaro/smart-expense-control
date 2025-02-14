using AutoMapper;
using SmartExpenseControl.Application.Commands.CreateExpense;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Profiles;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>().ReverseMap();
        CreateMap<ExpenseSummary, Expense>().ReverseMap();
    }
}
