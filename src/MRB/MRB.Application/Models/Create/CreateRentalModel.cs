using MRB.Domain.Entities;

namespace MRB.Domain.Models.Create;

public abstract record CreateRentalModel(
    string Identifier,
    DeliveryPerson deliveryPerson,
    DateTime end,
    DateTime? expectedReturnDate);