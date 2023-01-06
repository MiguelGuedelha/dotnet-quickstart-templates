using FluentValidation;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;

public sealed class ExampleFeatureGetQueryValidator : AbstractValidator<ExampleFeatureGetQuery>
{
    public ExampleFeatureGetQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .InclusiveBetween(1, 5)
            .WithMessage("Id must be between 1 and 5 (inclusive)");

        var options = new List<string> { "asc", "desc" };
        RuleFor(x => x.Sort)
            .NotEmpty()
            .Must(x => options.Contains(x.ToLowerInvariant()))
            .WithMessage($"Please only use: {string.Join(" | ", options)} (case insensitive)");
    }
}
