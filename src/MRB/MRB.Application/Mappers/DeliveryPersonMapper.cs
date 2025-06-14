using MRB.Application.Models.Create;
using MRB.Domain.Entities;

namespace MRB.Application.Mappers;

public class DeliveryPersonMapper
{
    public static DeliveryPerson FromModel(CreateDeliveryPersonModel model)
    {
        return new DeliveryPerson(
            model.Name,
            model.TaxId,
            model.BirthDate,
            model.DriverLicenseNumber,
            model.DriverLicense,
            model.DriverLicenseImage,
            model.identifier,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow,
            deletedAt: null);
    }

}