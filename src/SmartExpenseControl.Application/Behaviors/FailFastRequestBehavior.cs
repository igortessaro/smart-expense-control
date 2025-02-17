using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Behaviors;

public sealed class FailFastRequestBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> where TResponse : Message
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures = validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        return failures.Any()
            ? Errors(failures)
            : next();
    }

    private static Task<TResponse> Errors(IList<ValidationFailure> failures)
    {
        var notifications = failures.Select(x => new Notification(x.ErrorCode, x.ErrorMessage)).ToList();
        var message = Message.CreateErrors(notifications);
        return Task.FromResult(message as TResponse)!;
    }
}
