using MRB.Application.Abstractions;
using MRB.Application.Mappers;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Infra.Data.Abstractions;

namespace MRB.Application.Implementations;

public class DeliveryPersonService(IDeliveryPersonRepository deliveryPersonRepository, IUnitOfWork unitOfWork) : IDeliveryPersonService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDeliveryPersonRepository _deliveryPersonRepository = deliveryPersonRepository;
    
    public async Task Save(CreateDeliveryPersonModel model)
    {
        var entity = DeliveryPersonMapper.FromModel(model);
        
        await _deliveryPersonRepository.SaveAsync(entity);
        
        await _unitOfWork.CommitAsync();
    }

    public async Task<bool> UpdateDriverLicenseImage(string newDriverLicenseImage, string identifier)
    {
        var deliveryPerson = await _deliveryPersonRepository.GetByIdentifier(identifier);

        if (deliveryPerson is null)
            return false;
        
        deliveryPerson.UpdateDriverLicenseImage(newDriverLicenseImage);
        
        await _unitOfWork.CommitAsync();
        
        return true;
    }
}