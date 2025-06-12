using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRB.Application.Abstractions;
using MRB.Application.Models.Create;
using MRB.Domain.Models.Create;
using MRB.Infra.Data.Abstractions;
using MRB.Infra.IoC;
using MTB.Api.Contracts;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var motorcycles = app.MapGroup("/motorcycles").WithOpenApi();

motorcycles.MapPost("/", CreateMotorcycle).WithOpenApi();
motorcycles.MapGet("/", GetMotorcycles).WithOpenApi();
motorcycles.MapPut("/{id:long}/licensePlate", UpdateLicensePlate).WithOpenApi();
motorcycles.MapGet("/{id:long}", GetMotorcycleById).WithOpenApi();
motorcycles.MapDelete("/{id:long}", DeleteMotorcycle).WithOpenApi();

var deliveryPeople = app.MapGroup("/deliveryPeople").WithOpenApi();

deliveryPeople.MapPost("/", CreateDeliveryPerson).WithOpenApi();
deliveryPeople.MapPost("/{id:long}/driverLicense", UploadDriverLicense).WithOpenApi();

var rentals = app.MapGroup("/rentals").WithOpenApi();

rentals.MapPost("/", CreateRental).WithOpenApi();
rentals.MapGet("/{id:long}", GetRentalById).WithOpenApi();
rentals.MapPut("/{id:long}/return", ReturnRental).WithOpenApi();

app.Run();


static async Task<IResult> CreateMotorcycle(
    [FromBody] CreateRentalRequest model,
    IUnitOfWork unitOfWork,
    IMotorcycleService motorcycleService)
{
    try
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(model);

        if (!Validator.TryValidateObject(model, context, validationResults, true))
            return Results.BadRequest(new { mensagem = "Dados inválidos" });

        var createMotorcycleModel =
            new CreateMotorcycleModel(model.Identificador, model.Ano, model.Modelo, model.Placa);

        await motorcycleService.Save(createMotorcycleModel);

        await unitOfWork.CommitAsync();

        //publish event
    }
    catch (Exception ex)
    {
        if (ex is DbUpdateException)
            return Results.BadRequest(new { mensagem = "Moto já cadastrada" });
    }

    return Results.Accepted();
}

static async Task<IResult> GetMotorcycles(
    string? licensePlate,
    IMotorcycleService motorcycleService)
{
    // TODO: To a DTO
    return string.IsNullOrWhiteSpace(licensePlate)
        ? Results.Ok(await motorcycleService.GetAll())
        : Results.Ok(await motorcycleService.GetByLicensePlate(licensePlate));
}

static async Task<IResult> UpdateLicensePlate(long id)
{
    return Results.Ok();
}

static async Task<IResult> GetMotorcycleById(long id)
{
    return Results.Ok();
}

static async Task<IResult> DeleteMotorcycle(long id)
{
    return Results.Ok();
}

static async Task<IResult> CreateDeliveryPerson(CreateDeliveryPersonModel model)
{
    return Results.Ok();
}

static async Task<IResult> UploadDriverLicense(string driverLicense)
{
    return Results.Ok();
}

static async Task<IResult> CreateRental(CreateRentalModel model)
{
    return Results.Ok();
}

static async Task<IResult> GetRentalById(long id)
{
    return Results.Ok();
}

static async Task<IResult> ReturnRental(long id)
{
    return Results.Ok();
}