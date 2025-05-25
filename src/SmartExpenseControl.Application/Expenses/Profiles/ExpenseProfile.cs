using AutoMapper;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.Entities;
using SmartExpenseControl.Domain.ExpenseGroups.Models;

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
