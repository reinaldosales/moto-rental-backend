using MRB.Application.Abstractions;
using MRB.Application.Mappers;
using MRB.Domain.Abstractions;
using MRB.Domain.Models.Create;

namespace MRB.Application.Implementations;

public class RentalService(IRentalRepository rentalRepository) : IRentalService
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    
    public async Task Save(CreateRentalModel model)
    {
        var entity = RentalMapper.FromModel(model);
        
        await _rentalRepository.SaveAsync(entity);
    }
}