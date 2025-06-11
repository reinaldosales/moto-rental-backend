using MRB.Domain.Enums;

namespace MRB.Application.Models.Create;

public record CreateDeliveryPersonModel(
    string Name,
    string TaxId,
    DateTime BirthDate,
    string DriverLicenseNumber,
    DriverLicense DriverLicense,
    string? DriverLicenseImage);