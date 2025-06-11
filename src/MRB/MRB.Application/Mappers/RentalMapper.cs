using MRB.Domain.Entities;
using MRB.Domain.Models.Create;

namespace MRB.Application.Mappers;

public class RentalMapper
{
    public static Rental FromModel(CreateRentalModel model)
    {
        return new Rental(
            model.deliveryPerson,
            model.end,
            model.expectedReturnDate,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow,
            deletedAt: null);
    }
}