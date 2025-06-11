using MRB.Domain.Models.Create;

namespace MRB.Application.Abstractions;

public interface IRentalService
{
    public Task Save(CreateRentalModel model);
}