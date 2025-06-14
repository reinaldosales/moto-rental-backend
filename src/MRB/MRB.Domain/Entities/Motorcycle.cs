namespace MRB.Domain.Entities;

public class Motorcycle : BaseEntity<long>
{
    public Motorcycle()
    {
        
    }

    public Motorcycle(
        short year,
        string model,
        string licensePlate,
        string identifier,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime? deletedAt) : base(identifier ,createdAt, updatedAt, deletedAt)
    {
        Year = year;
        Model = model;
        LicensePlate = licensePlate;
    }
    
    public short Year { get; private set; }
    public string Model { get; private set; }
    public string LicensePlate { get; private set; }
    
    public void UpdateLicensePlate(string newLicensePlate)
        => LicensePlate = newLicensePlate;
}