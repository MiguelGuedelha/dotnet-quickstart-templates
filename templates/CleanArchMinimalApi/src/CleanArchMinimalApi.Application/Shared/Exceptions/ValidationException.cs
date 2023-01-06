using System.Diagnostics.CodeAnalysis;

namespace CleanArchMinimalApi.Application.Shared.Exceptions;

internal sealed class ValidationException : Exception
{
    public required IReadOnlyDictionary<string, string[]> Errors { get; init; }

    [SetsRequiredMembers]
    public ValidationException(IDictionary<string, string[]> errors) : base("One or more validation errors occured")
    {
        Errors = errors.AsReadOnly();
    }
}
