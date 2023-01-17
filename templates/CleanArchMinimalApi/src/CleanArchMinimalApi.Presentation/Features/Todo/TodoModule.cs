using CleanArchMinimalApi.Application.Features.Todo.Commands;
using CleanArchMinimalApi.Application.Features.Todo.Responses;
using CleanArchMinimalApi.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.Features.Todo;

public class TodoModule : CarterModule
{
    public TodoModule() : base("/todo")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app) =>
        app.MediatePost<CreateTodoCommand, CreateTodoResponse>("/");
}
