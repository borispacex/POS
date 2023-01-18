using POS.Api.Extensions;
using POS.Application.Extensions;
using POS.Infraestructure.Extensions;
using System.Configuration;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Cors
var Cors = "Cors";

// La conexion con la BD esta en Insfraestructure/Extensions/InjectionExtensions
var configuration = builder.Configuration;
builder.Services.AddInjectionInfraestructure(configuration);
// Injectamos la capa de aplicacion
builder.Services.AddInjectionApplication(configuration);
// Injectamos la documentacion de SWAGGER
builder.Services.AddAuthentication(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors, builder =>
    {
        builder.WithOrigins("*");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
// minusculas URL
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);


var app = builder.Build();

app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// WatchDog
app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(config =>
{
    config.WatchPageUsername = configuration.GetSection("WatchDog:Username").Value;
    config.WatchPagePassword = configuration.GetSection("WatchDog:Password").Value;
});

app.Run();

// Para que pueda ser accesible en nuestra capa de TEST
public partial class Program { }