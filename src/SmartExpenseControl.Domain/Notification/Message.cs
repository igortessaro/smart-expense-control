namespace SmartExpenseControl.Domain.Notification;

public class Message
{
    private readonly List<Notification> _notifications;

    public Message(object? data, IReadOnlyList<Notification> notifications)
    {
        _notifications = notifications.ToList();
        Data = data;
    }

    public Message(List<Notification>? notifications)
    {
        _notifications = notifications ?? [];
    }

    public bool IsSuccess => !_notifications.Any();
    public bool IsFailed => _notifications.Any();
    public object? Data { get; }
    public IReadOnlyList<Notification> Notifications => _notifications;

    public Message AddNotification(string key, string message) => AddNotifications([new Notification(key, message)]);
    public Message AddNotifications(params List<Notification> notifications)
    {
        _notifications.AddRange(notifications);
        return this;
    }

    public static Message Ok(object data) => new(data, []);
    public static Message Fail(params List<Notification> notifications) => new(null, notifications);
    public Message<TResult> Parse<TResult>() where TResult : class => Message<TResult>.Fail(_notifications);
}

public class Message<T> : Message where T : class
{
    public Message(T? data, IReadOnlyList<Notification> notifications) : base(data, notifications) { }
    public Message(List<Notification>? notifications) : base(notifications) { }

    public T? GetData() => (T?) base.Data;
    // public Message<TResult> Parse<TResult>() where TResult : class => new(null, Notifications);

    public static Message<T> Ok(T data) => new(data, []);
    public static new Message<T> Fail(params List<Notification> notifications) => new(null, notifications);
    public static implicit operator Message<T>(T payload) => new Message<T>(payload, []);
    public static implicit operator Message<T>(Notification notification) => Message<T>.Fail(notification);
    public static implicit operator Message<T>(List<Notification> notifications) => Message<T>.Fail(notifications);
}

public record Notification(string Key, string Message);
