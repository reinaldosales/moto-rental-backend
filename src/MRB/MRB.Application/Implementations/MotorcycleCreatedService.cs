using MRB.Application.Abstractions;
using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Infra.Data.Abstractions;

namespace MRB.Application.Implementations;

public class MotorcycleCreatedService(
    IMotorcycleCreatedRepository motorcycleCreatedRepository,
    IUnitOfWork unitOfWork) : IMotorcycleCreatedService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMotorcycleCreatedRepository _motorcycleCreatedRepository = motorcycleCreatedRepository;

    public async Task MotorcycleCreated(MotorcycleCreated motorcycleCreated)
    {
        await _motorcycleCreatedRepository.Save(motorcycleCreated);
        
        await _unitOfWork.CommitAsync();
    }
}