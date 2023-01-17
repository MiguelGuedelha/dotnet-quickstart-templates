using CleanArchMinimalApi.Application.Abstractions.Command;
using CleanArchMinimalApi.Application.Features.Todo.Commands;
using CleanArchMinimalApi.Application.Features.Todo.Responses;
using CleanArchMinimalApi.Application.Features.Todo.Services;
using CleanArchMinimalApi.Shared.Helpers;

namespace CleanArchMinimalApi.Application.Features.Todo.Handlers;

public class CreateTodoHandler : ICommandHandler<CreateTodoCommand, CreateTodoResponse>
{
    private readonly ITodoCommandService _todoCommandService;

    public CreateTodoHandler(ITodoCommandService todoCommandService) =>
        ArgumentHelper.Initialise(todoCommandService, out _todoCommandService);

    public async Task<CreateTodoResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var response = await _todoCommandService.CreateTodo(request, cancellationToken);
        return response;
    }
}
