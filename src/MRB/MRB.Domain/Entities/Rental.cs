using MRB.Domain.Enums;
using MRB.Domain.Exceptions;

namespace MRB.Domain.Entities;

public class Rental : BaseEntity<long>
{
    public Rental()
    {
    }

    public Rental(
        Motorcycle motorcycle,
        DeliveryPerson deliveryPerson,
        DateTime start,
        DateTime end,
        DateTime? expectedReturnDate,
        string identifier,
        RentalPlan plan,
        decimal fine,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime? deletedAt) : base(identifier, createdAt, updatedAt, deletedAt)
    {
        Motorcycle = motorcycle;
        DeliveryPerson = deliveryPerson;
        Start = start;
        End = end;
        ExpectedReturnDate = expectedReturnDate;
        InitiatedAt = createdAt.AddDays(1);
        Plan = plan;
        Fine = fine;

        if (Validate())
            throw new CreateRentalException($"The driver license of {deliveryPerson.Name} is not A.");
    }

    public Motorcycle Motorcycle { get; private set; }
    public DeliveryPerson DeliveryPerson { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public DateTime? ExpectedReturnDate { get; private set; }
    public DateTime InitiatedAt { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public RentalPlan Plan { get; private set; }
    public decimal Fine { get; set; }

    private bool Validate() => DeliveryPerson.DriverLicense != DriverLicense.A;

    public decimal GetAmountPerDay()
        => Plan switch
        {
            RentalPlan.SevenDays => 30M,
            RentalPlan.FifteenDays => 28M,
            RentalPlan.ThirtyDays => 22M,
            RentalPlan.FortyFiveDays => 20M,
            RentalPlan.FivetyDays => 18M,
            _ => 0M
        };

    public void UpdateReturnDate(DateTime modelDataDevolucao)
    {
        ReturnDate = modelDataDevolucao;
    }

    public void UpdateFine(decimal fine)
    {
        throw new NotImplementedException();
    }
}