using CleanArchMinimalApi.Application.Abstractions.Services;
using CleanArchMinimalApi.Application.Features.Todo.Commands;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Application.Features.Todo.Responses;
using CleanArchMinimalApi.Application.Shared.Exceptions;
using CleanArchMinimalApi.Application.Shared.Services;
using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

public class TodoCommandService : ITodoCommandService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IDateTimeService _dateTimeService;

    public TodoCommandService(
        ITodoRepository todoRepository, 
        IDateTimeService dateTimeService)
    {
        _todoRepository = todoRepository;
        _dateTimeService = dateTimeService;
    }

    public async Task<CreateTodoResponse> CreateTodo(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var todo = new TodoItem
        {
            Title = command.Body.Title, 
            Note = command.Body.Note, 
            Done = false,
            Created = _dateTimeService.Now(),
        };

        var created = await _todoRepository.CreateTodoItem(todo);

        if (!created)
        {
            throw new ServiceException<TodoCommandService>("Failed to create Todo");
        }
        
        return CreateTodoResponse.MapFromTodoItem(todo);
    }
}
