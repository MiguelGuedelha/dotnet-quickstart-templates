using CleanArchMinimalApi.Application.Features.Todo.Services;
using CleanArchMinimalApi.Application.Shared.Mediator;
using CleanArchMinimalApi.Shared.Helpers;

namespace CleanArchMinimalApi.Application.Features.Todo.GetTodo;

internal sealed class GetTodoQueryHandler : IQueryHandler<GetTodoQuery, GetTodoQueryResult>
{
    private readonly ITodoQueryService _todoQueryService;

    public GetTodoQueryHandler(ITodoQueryService todoQueryService)
    {
        _todoQueryService = ArgumentHelper.Initialise(todoQueryService);
    }

    public async Task<GetTodoQueryResult> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        return await _todoQueryService.GetTodo(request, cancellationToken);
    }
}
