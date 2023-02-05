using CleanArchMinimalApi.Presentation.Features.Todo.CreateTodo;
using CleanArchMinimalApi.Presentation.Features.Todo.GetTodo;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.Features.Todo;

public class TodoModule : CarterModule
{
    private const string GetTodoEndpointName = "GetTodo";

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
           .MapGroup("/todos")
           .WithTags("Todos");

        group.MapPost("/", CreateTodo);
        group.MapGet("/{id}", GetTodo)
           .WithName(GetTodoEndpointName);
    }

    private static async Task<CreatedAtRoute<CreateTodoResponse>> CreateTodo(
        ISender sender,
        [AsParameters] CreateTodoRequest request,
        CancellationToken cancellationToken)
    {
        var command = CreateTodoRequest.MapToCommand(request);
        var result = await sender.Send(command, cancellationToken);
        var response = CreateTodoResponse.MapFromCommandResponse(result);
        return TypedResults.CreatedAtRoute(response, GetTodoEndpointName, new
        {
            response.Id
        });
    }

    private static async Task<Results<Ok<GetTodoResponse>, NotFound<ProblemHttpResult>>> GetTodo(
        ISender sender,
        [AsParameters] GetTodoRequest request,
        CancellationToken cancellationToken)
    {
        var query = GetTodoRequest.MapToCommand(request);
        var result = await sender.Send(query, cancellationToken);
        var response = GetTodoResponse.MapFromQueryResponse(result);
        return TypedResults.Ok(response);
    }
}
