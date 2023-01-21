using CleanArchMinimalApi.Application.Features.Todo.Services;
using CleanArchMinimalApi.Application.Shared.Mediator;
using CleanArchMinimalApi.Shared.Helpers;

namespace CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, CreateTodoCommandResult>
{
    private readonly ITodoCommandService _todoCommandService;

    public CreateTodoCommandHandler(ITodoCommandService todoCommandService)
    {
        ArgumentHelper.Initialise(todoCommandService, out _todoCommandService);
    }

    public async Task<CreateTodoCommandResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        return await _todoCommandService.CreateTodo(request, cancellationToken);
    }
}
