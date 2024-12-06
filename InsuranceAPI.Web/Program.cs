using FluentValidation;
using FluentValidation.AspNetCore;
using InsuranceAPI.Application.Interfaces;
using InsuranceAPI.Application.Services;
using InsuranceAPI.Domain.Interfaces;
using InsuranceAPI.Infrastructure.Data;
using InsuranceAPI.Infrastructure.Repositories;
using InsuranceAPI.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IInsuredService, InsuredService>();
builder.Services.AddScoped<IInsuranceProductService, InsuranceProductService>();
builder.Services.AddScoped<IInsuredRepository, InsuredRepository>();
builder.Services.AddScoped<IInsuranceProductRepository, InsuranceProductRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers();
app.Run();
