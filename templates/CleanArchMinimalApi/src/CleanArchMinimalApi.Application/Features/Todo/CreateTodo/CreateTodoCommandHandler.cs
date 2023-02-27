using CleanArchMinimalApi.Application.Abstractions.Mediator;
using CleanArchMinimalApi.Application.Features.Todo.Services;
using CleanArchMinimalApi.Shared.Helpers;

namespace CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

internal sealed class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, CreateTodoCommandResult>
{
    private readonly ITodoCommandService _todoCommandService;

    public CreateTodoCommandHandler(ITodoCommandService todoCommandService)
    {
        _todoCommandService = ArgumentHelper.Initialise(todoCommandService);
    }

    public async Task<CreateTodoCommandResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        return await _todoCommandService.CreateTodo(request, cancellationToken);
    }
}
