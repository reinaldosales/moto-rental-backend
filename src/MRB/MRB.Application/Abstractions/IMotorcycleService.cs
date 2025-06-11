using MRB.Domain.Models.Create;

namespace MRB.Application.Abstractions;

public interface IMotorcycleService
{
    public Task Save(CreateMotorcycleModel model);
}