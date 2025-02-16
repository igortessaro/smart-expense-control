namespace SmartExpenseControl.Domain.Notification;

public class Message
{
    private readonly List<string> _errors = [];

    protected Message() { }

    public bool IsSuccess => !_errors.Any();
    public IReadOnlyList<string> Errors => _errors;

    protected Message AddError(string error)
    {
        _errors.Add(error);
        return this;
    }

    protected Message AddErrors(IReadOnlyList<string> errors)
    {
        _errors.AddRange(errors);
        return this;
    }

    public static Message CreateSuccess() => new Message();
}
