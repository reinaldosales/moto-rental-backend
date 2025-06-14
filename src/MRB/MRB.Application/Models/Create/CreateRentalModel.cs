using MRB.Domain.Entities;
using MRB.Domain.Enums;

namespace MRB.Application.Models.Create;

public record CreateRentalModel(
    string DeliveryPersonIdentifier,
    string MotorcycleIdentifier,
    DateTime Start,
    DateTime End,
    DateTime? ExpectedReturnDate,
    RentalPlan Plan);