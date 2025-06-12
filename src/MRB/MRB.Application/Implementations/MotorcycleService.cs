using MRB.Application.Abstractions;
using MRB.Application.Mappers;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Domain.Models.Create;

namespace MRB.Application.Implementations;

public class MotorcycleService(IMotorcycleRepository motorcycleRepository) : IMotorcycleService
{
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    
    public async Task Save(CreateMotorcycleModel model)
    {
        var entity = MotorcycleMapper.FromModel(model);
        
        await _motorcycleRepository.Save(entity);
    }

    public async Task<IEnumerable<Motorcycle>> GetAll()
    {
        return await _motorcycleRepository.GetAll();
    }

    public async Task<Motorcycle> GetByLicensePlate(string licensePlate)
    {
        return await _motorcycleRepository.GetByLicensePlate(licensePlate);
    }
}