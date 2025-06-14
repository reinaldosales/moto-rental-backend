using MassTransit;
using MRB.Application.Abstractions;

namespace MRB.Bus.Implementations;

public class EventPublisher(IPublishEndpoint publishEndpoint) : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public Task PublishAsync<T>(T @event) where T : class
    {
        return _publishEndpoint.Publish(@event);
    }
}