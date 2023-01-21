using FluentValidation;

namespace CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(150);

        RuleFor(x => x.Note)
            .MaximumLength(300);
    }
}
