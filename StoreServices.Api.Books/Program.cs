using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Books.Application;
using StoreServices.Api.Books.Data;
using System.Reflection;
using static StoreServices.Api.Books.Application.New;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddDbContext<ContextBook>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ExecuteValidator>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(Query.Execute));

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
