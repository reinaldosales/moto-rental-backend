using MRB.Domain.Enums;

namespace MRB.Domain.Entities;

public class DeliveryPerson : BaseEntity<long>
{
    public DeliveryPerson()
    {
        
    }

    public DeliveryPerson(
        string name,
        string taxId,
        DateTime birthDate,
        string driverLicenseNumber,
        DriverLicense driverLicense,
        string? driverLicenseImage,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime? deletedAt) : base(createdAt, updatedAt, deletedAt)
    {
        Name = name;
        TaxId = taxId;
        BirthDate = birthDate;
        DriverLicenseNumber = driverLicenseNumber;
        DriverLicense = driverLicense;
        DriverLicenseImage = driverLicenseImage;
    }

    public string Name { get; private set; }
    public string TaxId { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string? DriverLicenseNumber { get; private set; }
    public DriverLicense? DriverLicense { get; private set; }
    public string? DriverLicenseImage { get; private set; }
}