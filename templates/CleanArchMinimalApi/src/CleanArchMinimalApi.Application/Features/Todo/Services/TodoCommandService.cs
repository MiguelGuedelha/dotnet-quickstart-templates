using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Application.Shared.Exceptions;
using CleanArchMinimalApi.Application.Shared.Services;
using CleanArchMinimalApi.Domain.Features.Todo;
using CleanArchMinimalApi.Shared.Helpers;
using Microsoft.Extensions.Logging;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

internal sealed class TodoCommandService : ITodoCommandService
{
    private readonly ICorrelationIdService _correlationIdService;
    private readonly IDateTimeService _dateTimeService;
    private readonly ILogger<TodoCommandService> _logger;
    private readonly ITodoRepository _todoRepository;

    public TodoCommandService(
        ITodoRepository todoRepository,
        IDateTimeService dateTimeService,
        ILogger<TodoCommandService> logger,
        ICorrelationIdService correlationIdService)
    {
        _correlationIdService = ArgumentHelper.Initialise(correlationIdService);
        _todoRepository = ArgumentHelper.Initialise(todoRepository);
        _dateTimeService = ArgumentHelper.Initialise(dateTimeService);
        _logger = ArgumentHelper.Initialise(logger);
    }

    public async Task<CreateTodoCommandResult> CreateTodo(
        CreateTodoCommand command,
        CancellationToken cancellationToken)
    {
        var todo = new TodoItem
        {
            Title = command.Title,
            Note = command.Note,
            Done = false,
            Created = _dateTimeService.Now()
        };

        var created = await _todoRepository.CreateTodoItem(todo, cancellationToken);

        _logger.LogInformation("Finished CreateTodoRequest | Id: {@CorrelationId}",
                               _correlationIdService.GetCorrelationId());

        if (!created)
            throw new CreationFailedException<TodoCommandService>("Failed to create Todo");

        return CreateTodoCommandResult.MapFromTodoItem(todo);
    }
}
