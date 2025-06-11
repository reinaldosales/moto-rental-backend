using MRB.Application.Abstractions;
using MRB.Application.Mappers;
using MRB.Domain.Abstractions;
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
}