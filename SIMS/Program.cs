using Microsoft.EntityFrameworkCore;
using SIMS.Context;
using SIMS.Dtos;
using SIMS.Models;
using SIMS.Profiles;
using SIMS.Repositories;
using SIMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SimsDbContext>(options=>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISimsRepo<Student>, SimsRepo<Student>>();
builder.Services.AddScoped<ISimsRepo<StudentDto>, SimsRepo<StudentDto>>();
builder.Services.AddScoped<ISimsRepo<Course>, SimsRepo<Course>>();
builder.Services.AddScoped<ISimsRepo<Grade>, SimsRepo<Grade>>();
builder.Services.AddScoped<ISimsRepo<StudentCourse>, SimsRepo<StudentCourse>>();
builder.Services.AddScoped<ThirdPartyApiClient>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

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
