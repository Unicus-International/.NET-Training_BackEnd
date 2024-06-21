using Microsoft.EntityFrameworkCore;

using PresentOverviewAPI.Controllers.Interface;
using PresentOverviewAPI.Services.dbContext;
using PresentOverviewAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IPeopleController, PeopleController>();
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
