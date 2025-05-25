using SmartExpenseControl.Domain.ExpenseGroups.Entities;

namespace SmartExpenseControl.Domain.ExpenseGroups.Specifications;

public class ExpenseSpecification
{
    public bool IsSatisfiedBy(Expense expense)
    {
        // Business rules for validating an expense
        return expense.Amount > 0;
    }
}
