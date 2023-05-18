using Microsoft.EntityFrameworkCore;
using SIMS.Context;
using SIMS.Models;
using SIMS.Repositories;
using SIMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SimsDbContext>(options=>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<ISimsRepo<Student>, SimsRepo<Student>>();

builder.Services.AddHttpClient<ThirdPartyApiService>(client => 
{
    client.BaseAddress = new Uri("https://date.nager.at");
});

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
