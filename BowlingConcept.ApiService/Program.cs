using BowlingConcept.Application;
using BowlingConcept.Application.Dependency;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddBowlingConceptModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/lane", (GetBowlingLanesHandler handler) => handler.Query());

app.MapGet("/lane/{id}/score", (GetScoreboardHandler handler, Guid id) => handler.Query(id));

app.MapPost("/lane/{id}", (StartNewGameHandler handler, Guid id, [FromBody] string[] playerNames) => handler.Command(id, playerNames));

app.MapPost("/lane/{id}/topple", (BowlingPinsToppledHandler handler, Guid id, [FromQuery] int toppledPins) => handler.Command(id, toppledPins));

app.MapDefaultEndpoints();

app.Run();
