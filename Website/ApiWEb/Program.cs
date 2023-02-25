// 1. usando para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using ApiWEb.DataAccess;
using ApiWEb.Services;

var builder = WebApplication.CreateBuilder(args);

//. Conexion con DB sql server
const string DBname = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(DBname);
// 3. Agregar contexto

 builder.Services.AddDbContext<UniversityDbContext>(options =>options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();

//4.. Añadir Servicios personalizados
builder.Services.AddScoped<IStudentsInterface, StudentsServices>();
//TODO: Añidir el reato de interfaces

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPlicy", builder =>
    {
        builder.AllowAnyOrigin();//Cualquier app puede hacer peticion
        builder.AllowAnyMethod();//Cualquier metodo de peticion
        builder.AllowAnyHeader();//Cualquier cabecera
    });
});

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
//6 ABUSO DE CORS
app.UseCors("CorsPlicy");

app.Run();
