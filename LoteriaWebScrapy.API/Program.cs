using LoteriaWebScrapy.API.Datos;
using LoteriaWebScrapy.API.Servicios;
using LoteriaWebScrapy.API.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones
                .UseSqlite(builder.Configuration.GetConnectionString("cadena")));

builder.Services.AddScoped<IScrapyResultadosService, ScrapyResultadoQuinielaService>();
builder.Services.AddScoped<IObtenerResultadosService, ObtenerResultadosService>();


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
