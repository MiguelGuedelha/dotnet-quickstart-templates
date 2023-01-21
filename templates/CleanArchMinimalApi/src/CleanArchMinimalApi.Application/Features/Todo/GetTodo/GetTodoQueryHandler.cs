using CleanArchMinimalApi.Application.Abstractions.Mediator;
using CleanArchMinimalApi.Application.Features.Todo.Services;

namespace CleanArchMinimalApi.Application.Features.Todo.GetTodo;

internal sealed class GetTodoQueryHandler : IQueryHandler<GetTodoQuery, GetTodoQueryResult>
{
    private readonly ITodoQueryService _todoQueryService;

    public GetTodoQueryHandler(ITodoQueryService todoQueryService)
    {
        _todoQueryService = todoQueryService;
    }

    public async Task<GetTodoQueryResult> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        return await _todoQueryService.GetTodo(request, cancellationToken);
    }
}
