using CleanArchMinimalApi.Application.Features.Todo.Commands;
using FluentValidation;

namespace CleanArchMinimalApi.Application.Features.Todo.Validators;

public class CreatedTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreatedTodoCommandValidator()
    {
        RuleFor(x => x.Body.Title)
            .MaximumLength(150);

        RuleFor(x => x.Body.Note)
            .MaximumLength(300);
    }
}
