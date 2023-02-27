// 1. usando para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using ApiWEb.DataAccess;
using ApiWEb.Services;
using ApiWEb;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);

//. Conexion con DB sql server
const string DBname = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(DBname);
// 3. Agregar contexto

 builder.Services.AddDbContext<UniversityDbContext>(options =>options.UseSqlServer(connectionString));

//7. servicio de autenticacion con Token
builder.Services.AddJwtTokenServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();

//4.. Añadir Servicios personalizados
builder.Services.AddScoped<IStudentsInterface, StudentsServices>();

//8. Añadir autorizacion
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});
    

//TODO: Añidir el reato de interfaces

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//TODO: configarcion d swagger con  JWT
builder.Services.AddSwaggerGen(options =>
{
    //Definimos la seguridad para autorizacion
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name="Autorization",
        Type= SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description= "Autorizacion de JWT para ver la Lista"

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {

                    Type=ReferenceType.SecurityScheme,
                    Id= "Bearer"
                    }

                }, 
            new String[]{}
        }

    });
});

//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
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
app.UseCors("CorsPolicy");

app.Run();
