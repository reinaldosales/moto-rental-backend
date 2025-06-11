namespace MRB.Domain.Models.Create;

public abstract record CreateMotorcycleModel(
    short Year, 
    string Model,
    string LicensePlate);