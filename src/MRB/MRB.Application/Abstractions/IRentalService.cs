using MRB.Application.DTOs;
using MRB.Application.Models.Create;
using MRB.Domain.Entities;

namespace MRB.Application.Abstractions;

public interface IRentalService
{
    public Task Save(CreateRentalModel model);
    public Task<Rental> GetById(long id);
    public Task Return(string identifier, DateTime modelDataDevolucao);
    public Task<RentalDto> GetByIdentifier(string identifier);
}