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
        List<Task<ValidationResult>> validatorsTask = validators.Select(x => x.ValidateAsync(request, cancellationToken)).ToList();
        Task.WaitAll(validatorsTask, cancellationToken);
        List<ValidationFailure> failures = validatorsTask
            .SelectMany(validationResultTask =>
            {
                ValidationResult validationResult = validationResultTask.GetAwaiter().GetResult();
                return validationResult.Errors;
            })
            .Where(error => error != null)
            .ToList();

        return failures.Any()
            ? Errors(failures)
            : next();
    }

    private static Task<TResponse> Errors(IList<ValidationFailure> failures)
    {
        List<Notification> notifications = failures.Select(x => new Notification(x.ErrorCode, x.ErrorMessage)).ToList();
        Type messageType = typeof(TResponse);

        if (!messageType.IsGenericType || messageType.GetGenericTypeDefinition() != typeof(Message<>))
        {
            return Task.FromResult(Message.Fail(notifications) as TResponse)!;
        }

        var messageInstance = Activator.CreateInstance(messageType, notifications) as TResponse;
        return Task.FromResult(messageInstance as TResponse)!;
    }
}
