using CameraDeputados.Infra;
using CameraDeputados.Infra.Repositories;
using CameraDeputados.Infra.Repositories.Interfaces;
using CameraDeputados.Services.BaseDados;
using CameraDeputados.Services.Deputados;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = long.MaxValue);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serverVersion = new MySqlServerVersion(new Version(8,0,29));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("defaultConnection"), serverVersion));

builder.Services.AddScoped<IDeputadoService, DeputadoService>();
builder.Services.AddScoped<IDeputadoRepository, DeputadoRepostory>();
builder.Services.AddScoped<ICarregarBaseService, CarregarBaseService>();

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
