namespace SmartExpenseControl.Domain.Shared;

public class Notification
{
    private readonly List<Message> _notifications;

    protected Notification()
    {
        _notifications = [];
    }

    protected Notification(IReadOnlyList<Message> notifications)
    {
        _notifications = notifications.ToList();
    }

    private Notification(List<Message>? notifications)
    {
        _notifications = notifications ?? [];
    }

    public bool IsSuccess => !_notifications.Any();
    public bool IsFailed => _notifications.Any();
    public IReadOnlyList<Message> Notifications => _notifications;

    public Notification AddNotification(string key, string message) => AddNotifications([new Message(key, message)]);
    public Notification AddNotifications(params List<Message> notifications)
    {
        _notifications.AddRange(notifications);
        return this;
    }

    public static Notification Ok() => new();
    public static Notification Fail(params Message[] notifications) => new(notifications);
    public static Notification Fail(List<Message> notifications) => new(notifications);
    public Notification<TResult> Parse<TResult>() where TResult : class => Notification<TResult>.Fail(_notifications.ToArray());
}

public class Notification<T> : Notification where T : notnull
{
    private Notification(T payload) : base()
    {
        Payload = payload;
    }

    private Notification(IReadOnlyList<Message> notifications) : base(notifications) { }

    public Notification(List<Message> notifications) : base(notifications) { }

    public T? Payload { get; }

    public static Notification<T> Ok(T payload) => new(payload);
    public static new Notification<T> Fail(params Message[] notifications) => new(notifications);
    public static implicit operator Notification<T>(T payload) => new(payload);
    public static implicit operator Notification<T>(Message message) => Fail(message);
    public static implicit operator Notification<T>(Message[] notifications) => Fail(notifications);
}

public record Message(string Key, string Value);
