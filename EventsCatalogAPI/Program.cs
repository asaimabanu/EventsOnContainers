using EventsCatalogAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EventContext>(
    options => options.UseSqlServer(configuration["ConnectionString"]), 
    contextLifetime: ServiceLifetime.Transient, 
    optionsLifetime: ServiceLifetime.Transient);

var app = builder.Build();
var scope = app.Services.CreateScope();
var serviceProviders = scope.ServiceProvider;
var context = serviceProviders.GetRequiredService<EventContext>();
EventSeed.Seed(context);

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
