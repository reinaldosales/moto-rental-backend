using MRB.Application.Abstractions;
using MRB.Application.DTOs;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Domain.Enums;
using MRB.Infra.Data.Abstractions;

namespace MRB.Application.Implementations;

public class RentalService(
    IRentalRepository rentalRepository,
    IMotorcycleRepository motorcycleRepository,
    IDeliveryPersonRepository deliveryPersonRepository,
    IUnitOfWork unitOfWork) : IRentalService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    private readonly IDeliveryPersonRepository _deliveryPersonRepository = deliveryPersonRepository;

    public async Task Save(CreateRentalModel model)
    {
        var deliveryPerson = await _deliveryPersonRepository.GetByIdentifier(model.DeliveryPersonIdentifier)
                             ?? throw new Exception("No delivery person found");

        if (deliveryPerson.DriverLicense != DriverLicense.A)
            throw new Exception("Driver license invalid");

        var motorcycle = await _motorcycleRepository.GetByIdentifier(model.MotorcycleIdentifier)
                         ?? throw new Exception("No motorcycle found");

        if (!Enum.IsDefined(typeof(RentalPlan), model.Plan))
            throw new Exception("Invalid rental plan");

        if (model.Start < DateTime.Now.Date)
            throw new Exception("Invalid rental start date");

        if (model.Start >= model.End)
            throw new Exception("Invalid rental end");

        var rental = new Rental(
            motorcycle,
            deliveryPerson,
            model.Start,
            model.End,
            model.ExpectedReturnDate,
            identifier: Guid.NewGuid().ToString(),
            model.Plan,
            fine: 0M,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow,
            deletedAt: null
        );

        await _rentalRepository.SaveAsync(rental);

        await _unitOfWork.CommitAsync();
    }

    public async Task<Rental> GetById(long id)
    {
        return await _rentalRepository.GetById(id) ?? throw new Exception("No rental found");
    }

    public async Task Return(string identifier, DateTime modelDataDevolucao)
    {
        var rental = await _rentalRepository.GetByIdentifier(identifier)
            ?? throw new Exception("No rental found");

        if (modelDataDevolucao.Date < DateTime.Now.Date)
            throw new Exception("Return date invalid");

        decimal fine = 0M;

        if (modelDataDevolucao.Date < rental.ExpectedReturnDate.Value.Date)
        {
            var leftDays = (rental.ExpectedReturnDate.Value.Date - modelDataDevolucao.Date).Days;
            
            var amount = leftDays * rental.GetAmountPerDay();
            
            if (rental.Plan == RentalPlan.SevenDays)
                fine =+ amount * 0.20M;
            else if (rental.Plan == RentalPlan.FifteenDays)
                fine += amount * 0.40M;
        }
        else if (modelDataDevolucao > rental.ExpectedReturnDate)
        {
            var leftDays = (modelDataDevolucao.Date - rental.ExpectedReturnDate.Value.Date).Days;

            fine = leftDays * rental.GetAmountPerDay();
        }

        rental.UpdateReturnDate(modelDataDevolucao);
        rental.UpdateFine(fine);

        await _unitOfWork.CommitAsync();
    }

    public async Task<RentalDto> GetByIdentifier(string identifier)
    {
        var rental = await _rentalRepository.GetByIdentifier(identifier)
            ?? throw new Exception("No rental found");

        var rentalDto = new RentalDto(
            rental.Identifier,
            rental.GetAmountPerDay(),
            rental.DeliveryPerson.Identifier,
            rental.Motorcycle.Identifier,
            rental.Start,
            rental.End,
            rental.ExpectedReturnDate,
            rental.ReturnDate
        );

        return rentalDto;
    }
}