using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MRB.Api.Contracts;
using MRB.Application.Abstractions;
using MRB.Application.Helpers;
using MRB.Application.Models.Create;
using MRB.Infra.IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddMessaging(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var motorcycles = app.MapGroup("/motos").WithOpenApi();

motorcycles.MapPost("/", CreateMotorcycle).WithOpenApi();
motorcycles.MapGet("/", GetMotorcycles).WithOpenApi();
motorcycles.MapPut("/{id}/placa", UpdateLicensePlate).WithOpenApi();
motorcycles.MapGet("/{id}", GetMotorcycleById).WithOpenApi();
motorcycles.MapDelete("/{id}", DeleteMotorcycle).WithOpenApi();

var deliveryPeople = app.MapGroup("/entregadores").WithOpenApi();

deliveryPeople.MapPost("/", CreateDeliveryPerson).WithOpenApi();
deliveryPeople.MapPost("/{id}/cnh", UploadDriverLicense).WithOpenApi();

var rentals = app.MapGroup("/locacao").WithOpenApi();

rentals.MapPost("/", CreateRental).WithOpenApi();
rentals.MapGet("/{id}", GetRentalById).WithOpenApi();
rentals.MapPut("/{id}/devolucao", ReturnRental).WithOpenApi();

app.Run();


static async Task<IResult> CreateMotorcycle(
    [FromBody] CreateMotorcycleRequest model,
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

        await motorcycleService.CreateMotorCycle(createMotorcycleModel);

        return Results.Created();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { mensagem = "Dados inválidos" });
    }
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

static async Task<IResult> UpdateLicensePlate(
    string identifier,
    UpdateMotorcyleLicencePlateRequest model,
    IMotorcycleService motorcycleService)
{
    var validationResults = new List<ValidationResult>();
    var context = new ValidationContext(model);

    if (!Validator.TryValidateObject(model, context, validationResults, true))
        return Results.BadRequest(new { mensagem = "Dados inválidos" });

    var updated = await motorcycleService.UpdateLicensePlate(identifier, model.Placa);

    return updated
        ? Results.Ok(new { mensagem = "Placa modificada com sucesso" })
        : Results.BadRequest(new { mensagem = "Moto não encontrada" });
}

static async Task<IResult> GetMotorcycleById(
    string identifier,
    IMotorcycleService motorcycleService)
{
    try
    {
        var motorcycle = await motorcycleService.GetByIdentifier(identifier);

        return Results.Ok(motorcycle);
    }
    catch (Exception e)
    {
        return Results.NotFound(new { mensagem = "Moto não encontrada" });
    }
}

static async Task<IResult> DeleteMotorcycle(
    string identifier,
    IMotorcycleService motorcycleService)
{
    var updated = await motorcycleService.Delete(identifier);

    return updated
        ? Results.Ok()
        : Results.BadRequest(new { mensagem = "Dados inválidos" });
}

static async Task<IResult> CreateDeliveryPerson(
    CreateDeliveryPersonRequest model,
    IDeliveryPersonService deliveryPersonService)
{
    try
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(model);

        if (!Validator.TryValidateObject(model, context, validationResults, true))
            return Results.BadRequest(new { mensagem = "Dados inválidos" });
        
        var fullpath = ImageHelper.SaveBase64Image(model.Imagem_Cnh);

        var deliveryPersonModel = new CreateDeliveryPersonModel(
            model.Identificador,
            model.Nome,
            model.Cnpj,
            DateTime.SpecifyKind(model.Data_Nascimento, DateTimeKind.Utc),
            model.Numero_Cnh,
            model.Tipo_Cnh,
            fullpath);

        await deliveryPersonService.Save(deliveryPersonModel);

        return Results.Created();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { mensagem = "Dados inválidos" });
    }
}

static async Task<IResult> UploadDriverLicense(
    string identifier,
    UpdateDeliveryPersonDriverLicenseRequest model,
    IDeliveryPersonService deliveryPersonService)
{
    try
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(model);

        if (!Validator.TryValidateObject(model, context, validationResults, true))
            return Results.BadRequest(new { mensagem = "Dados inválidos" });

        var fullpath = ImageHelper.SaveBase64Image(model.Imagem_Cnh);

        await deliveryPersonService.UpdateDriverLicenseImage(fullpath, identifier);

        return Results.Created();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { mensagem = "Dados inválidos" });
    }
}

static async Task<IResult> CreateRental(
    CreateRentalRequest model,
    IRentalService rentalService)
{
    try
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(model);

        if (!Validator.TryValidateObject(model, context, validationResults, true))
            return Results.BadRequest(new { mensagem = "Dados inválidos" });

        var createRentalModel = new CreateRentalModel(
            model.Entregador_id,
            model.Moto_id,
            DateTime.SpecifyKind(model.Data_Inicio, DateTimeKind.Utc),
            DateTime.SpecifyKind(model.Data_Termino, DateTimeKind.Utc),
            DateTime.SpecifyKind(model.Data_Previsao_Termino, DateTimeKind.Utc),
            model.plano
        );

        await rentalService.Save(createRentalModel);

        return Results.Created();
    }
    catch (Exception e)
    {
        return Results.BadRequest(new { mensagem = "Dados inválidos" });
    }
}

static async Task<IResult> GetRentalById(
    string identifier,
    IRentalService rentalService)
{
    try
    {
        var rental = await rentalService.GetByIdentifier(identifier);

        return Results.Ok(rental);
    }
    catch (Exception e)
    {
        return Results.BadRequest(new { mensagem = "Dados inválidos" });
    }
}

static async Task<IResult> ReturnRental(
    string identifier,
    ReturnRentalRequest model,
    IRentalService rentalService)
{
    try
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(model);

        if (!Validator.TryValidateObject(model, context, validationResults, true))
            return Results.BadRequest(new { mensagem = "Dados inválidos" });
        
        await rentalService.Return(identifier, model.Data_Devolucao);

        return Results.Ok(new { mensagem = "Data de devolução informada com sucesso" });
    }
    catch (Exception e)
    {
        return Results.BadRequest(new { mensagem = "Dados inválidos" });
    }
}