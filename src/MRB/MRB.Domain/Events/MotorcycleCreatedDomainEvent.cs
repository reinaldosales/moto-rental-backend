namespace MRB.Domain.Events;

public class MotorcycleCreatedDomainEvent
{
    public MotorcycleCreatedDomainEvent(short year, string model, string licensePlate, DateTime createdAt)
    {
        Year = year;
        Model = model;
        LicensePlate = licensePlate;
        CreatedAt = createdAt;
    }

    public short Year { get; private set; }
    public string Model { get; private set; }
    public string LicensePlate { get; private set; }
    public DateTime CreatedAt { get; private set; }
}