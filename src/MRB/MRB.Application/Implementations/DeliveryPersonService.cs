using MRB.Application.Abstractions;
using MRB.Application.Mappers;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Domain.Models.Create;

namespace MRB.Application.Implementations;

public class DeliveryPersonService(IDeliveryPersonRepository deliveryPersonRepository) : IDeliveryPersonService
{
    private readonly IDeliveryPersonRepository _deliveryPersonRepository = deliveryPersonRepository;
    
    public async Task Save(CreateDeliveryPersonModel model)
    {
        var entity = DeliveryPersonMapper.FromModel(model);
        
        await _deliveryPersonRepository.SaveAsync(entity);
    }
}