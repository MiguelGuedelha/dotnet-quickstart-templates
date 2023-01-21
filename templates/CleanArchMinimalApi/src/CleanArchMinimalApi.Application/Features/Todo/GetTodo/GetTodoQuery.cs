using CleanArchMinimalApi.Application.Shared.Mediator;

namespace CleanArchMinimalApi.Application.Features.Todo.GetTodo;

public record GetTodoQuery : IQuery<GetTodoQueryResult>
{
    public Guid Id { get; init; }
}
