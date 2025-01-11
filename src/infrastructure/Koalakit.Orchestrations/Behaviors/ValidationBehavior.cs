using FluentValidation;
using FluentValidation.Results;
using KoalaKit.Primitives.Extensions;
using KoalaKit.Primitives.Results;

namespace Koalakit.Orchestrations.Behaviors;

public sealed class ValidationBehavior<TOperation, TResponse>(
    IEnumerable<IValidator<TOperation>> validators) :
    IKoalaBehavior<TOperation, TResponse>
    where TOperation : notnull
    where TResponse : KoalaResult
{
    readonly IEnumerable<IValidator<TOperation>> _validators = validators;

    public async Task<TResponse> Handle(TOperation request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next(cancellationToken);

        var errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .Select(ToWSError)
            .Distinct()
            .ToArray();

        if (errors.HasItems())
        {
            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(KoalaResult<>))
            {
                var genericArgument = typeof(TResponse).GetGenericArguments()[0];
                var failureMethod = typeof(KoalaResult)
                    .GetMethods()
                    .Where(m => m.Name == nameof(KoalaResult.Failure) && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 1)
                    .FirstOrDefault() ?? throw new InvalidOperationException("Could not find the generic Failure<T> method on WSResult.");

                var genericFailureMethod = failureMethod.MakeGenericMethod(genericArgument);
                var genericResult = genericFailureMethod.Invoke(null, [errors ?? []]) ?? throw new InvalidOperationException("Could Invoke method on WSResult.");
                return (TResponse)genericResult;
            }
            else
            {
                var result = KoalaResult.Failure(errors ?? []);
                return (TResponse)(object)result;
            }
        }
        return await next(cancellationToken);
    }

    private static KoalaError ToWSError(ValidationFailure error)
    {
        return KoalaError.BadRequest(error.ErrorCode);
    }
}