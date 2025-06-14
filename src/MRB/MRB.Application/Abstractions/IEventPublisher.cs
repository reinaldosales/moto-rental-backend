namespace MRB.Application.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event) where T : class;
}