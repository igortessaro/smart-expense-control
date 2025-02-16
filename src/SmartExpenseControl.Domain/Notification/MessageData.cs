namespace SmartExpenseControl.Domain.Notification;

public sealed class MessageData<T> : Message
{
    private MessageData() { }

    public MessageData(T? data) : this()
    {
        Data = data;
    }

    public T? Data { get; private set; }

    public MessageData<T> SetData(T? data)
    {
        Data = data;
        return this;
    }

    public static MessageData<T> CreateSuccess(T data) => new MessageData<T>(data);

    public static MessageData<T> CreateWithErrors(IReadOnlyList<string> errors)
    {
        var result = new MessageData<T>();
        result.AddErrors(errors);
        return result;
    }

    public static MessageData<T> CreateWithError(string error)
    {
        var result = new MessageData<T>();
        result.AddError(error);
        return result;
    }
}
