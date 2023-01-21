using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Application.Shared.Exceptions;
using CleanArchMinimalApi.Application.Shared.Services;
using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

public class TodoCommandService : ITodoCommandService
{
    private readonly IDateTimeService _dateTimeService;
    private readonly ITodoRepository _todoRepository;

    public TodoCommandService(
        ITodoRepository todoRepository,
        IDateTimeService dateTimeService)
    {
        _todoRepository = todoRepository;
        _dateTimeService = dateTimeService;
    }

    public async Task<CreateTodoCommandResult> CreateTodo(CreateTodoCommand command,
        CancellationToken cancellationToken)
    {
        var todo = new TodoItem
        {
            Title = command.Title, Note = command.Note, Done = false, Created = _dateTimeService.Now()
        };

        var created = await _todoRepository.CreateTodoItem(todo, cancellationToken);

        if (!created)
        {
            throw new CreationFailedException<TodoCommandService>("Failed to create Todo");
        }

        return CreateTodoCommandResult.MapFromTodoItem(todo);
    }
}
