using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.Application;
using SurveyBasket.Application.Contracts.Polls;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Application.Services;
using SurveyBasket.Infrastructure;
using SurveyBasket.Infrastructure.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Application and Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
