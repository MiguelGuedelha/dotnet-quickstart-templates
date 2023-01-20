using CleanArchMinimalApi.Presentation.Features.Todo.CreateTodo;
using CleanArchMinimalApi.Presentation.Features.Todo.GetTodo;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.Features.Todo;

public class TodoModule : CarterModule
{
    private const string GetTodoEndpointName = "GetTodo";

    public TodoModule() : base("/todo")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", CreateTodo);
        app.MapGet("/{id}", GetTodo)
            .WithName(GetTodoEndpointName);
    }

    private static async Task<IResult> CreateTodo(ISender sender, [AsParameters] CreateTodoRequest request,
        CancellationToken cancellationToken)
    {
        var command = CreateTodoRequest.MapToCommand(request);
        var result = await sender.Send(command, cancellationToken);
        var response = CreateTodoResponse.MapFromCommandResponse(result);
        return Results.CreatedAtRoute(GetTodoEndpointName, new { response.Id }, response);
    }

    private static async Task<IResult> GetTodo(ISender sender, [AsParameters] GetTodoRequest request,
        CancellationToken cancellationToken)
    {
        var query = GetTodoRequest.MapToCommand(request);
        var result = await sender.Send(query, cancellationToken);
        var response = GetTodoResponse.MapFromQueryResponse(result);
        return Results.Ok(response);
    }
}
