using MRB.Application.Models.Create;
using MRB.Domain.Entities;

namespace MRB.Application.Mappers;

public class MotorcycleMapper
{
    public static Motorcycle FromModel(CreateMotorcycleModel model)
    {
        return new Motorcycle(
            model.Year,
            model.Model,
            model.LicensePlate,
            model.Identifier,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow, 
            deletedAt: null);
    }
}