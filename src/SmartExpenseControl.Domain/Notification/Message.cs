namespace SmartExpenseControl.Domain.Notification;

public class Message
{
    private readonly List<Notification> _notifications;

    protected Message()
    {
        _notifications = [];
    }

    protected Message(IReadOnlyList<Notification> notifications)
    {
        _notifications = notifications.ToList();
    }

    private Message(List<Notification>? notifications)
    {
        _notifications = notifications ?? [];
    }

    public bool IsSuccess => !_notifications.Any();
    public bool IsFailed => _notifications.Any();
    public IReadOnlyList<Notification> Notifications => _notifications;

    public Message AddNotification(string key, string message) => AddNotifications([new Notification(key, message)]);
    public Message AddNotifications(params List<Notification> notifications)
    {
        _notifications.AddRange(notifications);
        return this;
    }

    public static Message Ok() => new();
    public static Message Fail(params Notification[] notifications) => new(notifications);
    public static Message Fail(List<Notification> notifications) => new(notifications);
    public Message<TResult> Parse<TResult>() where TResult : class => Message<TResult>.Fail(_notifications.ToArray());
}

public class Message<T> : Message where T : notnull
{
    private Message(T payload) : base()
    {
        Payload = payload;
    }

    private Message(IReadOnlyList<Notification> notifications) : base(notifications) { }

    public Message(List<Notification> notifications) : base(notifications) { }

    public T Payload { get; }

    public static Message<T> Ok(T payload) => new(payload);
    public static new Message<T> Fail(params Notification[] notifications) => new(notifications);
    public static implicit operator Message<T>(T payload) => new Message<T>(payload);
    public static implicit operator Message<T>(Notification notification) => Message<T>.Fail(notification);
    public static implicit operator Message<T>(Notification[] notifications) => Message<T>.Fail(notifications);
}

public record Notification(string Key, string Message);
