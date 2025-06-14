using MRB.Application.Abstractions;
using MRB.Application.DTOs;
using MRB.Application.Mappers;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Infra.Data.Abstractions;

namespace MRB.Application.Implementations;

public class MotorcycleService(IMotorcycleRepository motorcycleRepository, IUnitOfWork unitOfWork) : IMotorcycleService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;

    public async Task CreateMotorCycle(CreateMotorcycleModel model)
    {
        var entity = MotorcycleMapper.FromModel(model);

        await _motorcycleRepository.Save(entity);

        await _unitOfWork.CommitAsync();

        //publish event
    }

    public async Task<IEnumerable<MotorcycleDto>> GetAll()
    {
        var motorcycles = await _motorcycleRepository.GetAll();

        var motorcyclesDto = motorcycles.Select(x => new MotorcycleDto(x.Identifier, x.Year, x.Model, x.LicensePlate));

        return motorcyclesDto;
    }

    public async Task<MotorcycleDto> GetByLicensePlate(string licensePlate)
    {
        var motorcycle = await _motorcycleRepository.GetByLicensePlate(licensePlate);
        
        var motorcycleDto = new MotorcycleDto(
            motorcycle.Identifier,
            motorcycle.Year,
            motorcycle.Model,
            motorcycle.LicensePlate);

        return motorcycleDto;
    }

    public async Task<bool> UpdateLicensePlate(string identifier, string newLicensePlate)
    {
        var motorcycle = await _motorcycleRepository.GetByIdentifier(identifier);

        if (motorcycle is null)
            return false;

        motorcycle.UpdateLicensePlate(newLicensePlate);
        motorcycle.UpdateUpdatedAt();

        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<MotorcycleDto> GetById(long id)
    {
        var motorcycle = await _motorcycleRepository.GetById(id)
            ?? throw new Exception("Motorcycle not found");

        var motorcycleDto = new MotorcycleDto(
            motorcycle.Identifier,
            motorcycle.Year,
            motorcycle.Model,
            motorcycle.LicensePlate);

        return motorcycleDto;
    }

    public async Task<bool> Delete(string identifier)
    {
        var motorcycle = await _motorcycleRepository.GetByIdentifier(identifier);

        if (motorcycle is null)
            return false;

        motorcycle.Delete();
        motorcycle.UpdateUpdatedAt();

        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<MotorcycleDto> GetByIdentifier(string identifier)
    {
        var motorcycle = await _motorcycleRepository.GetByIdentifier(identifier)
            ?? throw new Exception("Motorcycle not found");

        var motorcycleDto = new MotorcycleDto(
            motorcycle.Identifier,
            motorcycle.Year,
            motorcycle.Model,
            motorcycle.LicensePlate);

        return motorcycleDto;
    }
}