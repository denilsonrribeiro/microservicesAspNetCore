using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Data;
using StoreServices.Api.Author.Model;
using System.Reflection;
using static StoreServices.Api.Author.Application.New;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddDbContext<ContextAuthor>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("PGConnection"));
});

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ExecuteValidador>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(Query.Handler));

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
