using MRB.Application.Models.Create;
using MRB.Domain.Models.Create;

namespace MRB.Application.Abstractions;

public interface IDeliveryPersonService
{
    public Task Save(CreateDeliveryPersonModel model);
}