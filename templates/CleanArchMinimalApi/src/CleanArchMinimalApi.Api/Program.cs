using CleanArchMinimalApi.Application;
using CleanArchMinimalApi.Infrastructure;
using CleanArchMinimalApi.Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddMvc()
//     .AddJsonOptions(options =>
//     {
//         options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
//     });

var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(configuration)
   .Enrich.FromLogContext()
   .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddPresentationServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UsePresentationServices();
app.UseApplicationServices();
app.UseInfrastructureServices();

app.Run();
