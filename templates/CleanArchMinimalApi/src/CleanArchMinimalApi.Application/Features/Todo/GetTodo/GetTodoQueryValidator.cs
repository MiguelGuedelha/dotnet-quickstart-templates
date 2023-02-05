using FluentValidation;

namespace CleanArchMinimalApi.Application.Features.Todo.GetTodo;

public class GetTodoQueryValidator : AbstractValidator<GetTodoQuery>
{
    public GetTodoQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotNull();
    }
}
