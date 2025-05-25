using SmartExpenseControl.Domain.ExpenseGroups;

namespace SmartExpenseControl.Domain.Specifications;

public class ExpenseSpecification
{
    public bool IsSatisfiedBy(Expense expense)
    {
        // Business rules for validating an expense
        return expense.Amount > 0;
    }
}
