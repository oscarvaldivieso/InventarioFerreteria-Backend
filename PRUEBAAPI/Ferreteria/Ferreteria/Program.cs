using FerreteriaDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Ferreteria.BussinessLogic;
using Ferreteria.Extensions;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FerreteriaConn");

builder.Services.AddDbContext<dbFerreteriaContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton(connectionString);
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.DataAccess(connectionString);
builder.Services.BusinessLogic();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(typeof(MappingProfileExtensions));
});

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