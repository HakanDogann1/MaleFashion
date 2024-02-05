using Autofac;
using Autofac.Extensions.DependencyInjection;
using MaleFashion.BusinessLayer.DependencyResolves.AutoFac;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DataAccessLayer.Context;
using MaleFashion.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureContainer<ContainerBuilder>(
   builder => builder.RegisterModule(new AutofacBusinessModule()));
// Add services to the container.
ProgramExtension.ProgramConfiguration(builder.Services, builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here.
// Don't call builder.Populate(), that happens in AutofacServiceProviderFactory.


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
