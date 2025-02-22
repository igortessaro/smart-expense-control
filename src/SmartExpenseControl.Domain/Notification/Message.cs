namespace SmartExpenseControl.Domain.Notification;

public class Message
{
    private readonly List<Notification> _notifications;

    protected Message(object? data, IReadOnlyList<Notification> notifications)
    {
        _notifications = notifications.ToList();
        Data = data;
    }

    public bool IsSuccess => !_notifications.Any();
    public object? Data { get; }
    public IReadOnlyList<Notification> Notifications => _notifications;

    public Message AddNotification(string key, string message) => AddNotifications([new Notification(key, message)]);
    public Message AddNotifications(IReadOnlyList<Notification> notifications)
    {
        _notifications.AddRange(notifications);
        return this;
    }

    public static Message CreateSuccess(object data) => new(data, []);
    public static Message CreateErrors(IReadOnlyList<Notification> notifications) => new(null, notifications);
}

public class Message<T> : Message where T : class
{
    private Message(T? data, IReadOnlyList<Notification> notifications)
        : base(data, notifications)
    {
    }

    public T? GetData() => (T?) base.Data;
    public Message<TResult> Parse<TResult>() where TResult : class => new(null, Notifications);

    public static Message<T> CreateSuccess(T data) => new(data, []);
    public new static Message<T> CreateErrors(IReadOnlyList<Notification> notifications) => new(null, notifications);
}

public record Notification(string Key, string Message);
