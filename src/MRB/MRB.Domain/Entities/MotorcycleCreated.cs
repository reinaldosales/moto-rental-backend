namespace MRB.Domain.Entities;

public class MotorcycleCreated : BaseEntity<long>
{
    public MotorcycleCreated(
        string identifier,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime? deletedAt,
        short year,
        string model,
        string licensePlate) : base(identifier, createdAt, updatedAt, deletedAt)
    {
        Year = year;
        Model = model;
        LicensePlate = licensePlate;
    }

    public short Year { get; private set; }
    public string Model { get; private set; }
    public string LicensePlate { get; private set; }
}