using MRB.Application.Models.Create;
using MRB.Domain.Entities;

namespace MRB.Application.Mappers;

public class RentalMapper
{
    public static Rental FromModel(CreateRentalModel model)
    {
        return new Rental();
    }
}