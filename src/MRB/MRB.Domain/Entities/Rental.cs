using MRB.Domain.Enums;
using MRB.Domain.Exceptions;

namespace MRB.Domain.Entities;

public class Rental : BaseEntity<long>
{
    public Rental()
    {
        
    }

    public Rental(
        DeliveryPerson deliveryPerson,
        DateTime end,
        DateTime? expectedReturnDate,
        string identifier,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime? deletedAt) : base(identifier, createdAt, updatedAt, deletedAt)
    {
        DeliveryPerson = deliveryPerson;
        Start = createdAt.AddDays(1);
        End = end;
        ExpectedReturnDate = expectedReturnDate;
        
        if(Validate())
            throw new CreateRentalException($"The driver license of {deliveryPerson.Name} is not A.");
    }

    public DeliveryPerson DeliveryPerson { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public DateTime? ExpectedReturnDate { get; private set; }
    
    private bool Validate() => DeliveryPerson.DriverLicense != DriverLicense.A;
}