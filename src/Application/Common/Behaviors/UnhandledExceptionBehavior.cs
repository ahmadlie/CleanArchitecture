namespace CleanArchitecture.Application.Common.Behaviors;
public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    public UnhandledExceptionBehavior(ILogger<TRequest> logger)
    {
        this._logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, Messages.UnhandledExceptionBehavior, requestName, request);
            throw;
        }
    }
}
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this._validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResult.Where(f => f.Errors.Any())
                .SelectMany(f => f.Errors)
                .ToList();


            //List<ValidationFailure> allErrors = new();
            //foreach (var error in validationResult.ToList())
            //{
            //    foreach (var errors in error.Errors)
            //    {
            //        allErrors.Add(errors);
            //    }
            //}

            if (failures.Any())
                throw new ValidationException(failures);

        }

        return await next();
    }
}
