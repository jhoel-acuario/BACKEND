// 1. usando para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using ApiWEb.DataAccess;
var builder = WebApplication.CreateBuilder(args);

//. Conexion con DB sql server
const string DBname = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(DBname);
// 3. Agregar contexto

 builder.Services.AddDbContext<UniversityDbContext>(options =>options.UseSqlServer(connectionString));


// Add services to the container.

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
