using MassTransit;
using MRB.Application.Abstractions;
using MRB.Domain.Entities;
using MRB.Domain.Events;

namespace MRB.Bus.Consumers;

public class MotorcycleCreatedConsumer(IMotorcycleCreatedService motorcycleCreatedService) : IConsumer<MotorcycleCreatedDomainEvent>
{
    private readonly IMotorcycleCreatedService _motorcycleCreatedService = motorcycleCreatedService;
    
    public async Task Consume(ConsumeContext<MotorcycleCreatedDomainEvent> context)
    {
        if (context.Message.Year != 2024)
            return;
        
        var entity = new MotorcycleCreated
        (
            identifier: Guid.NewGuid().ToString(),
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow,
            deletedAt: null,
            context.Message.Year,
            context.Message.Model,
            context.Message.LicensePlate
        );

        await motorcycleCreatedService.MotorcycleCreated(entity);
    }
}