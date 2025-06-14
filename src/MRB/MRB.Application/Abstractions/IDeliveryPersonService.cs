using MRB.Application.Models.Create;

namespace MRB.Application.Abstractions;

public interface IDeliveryPersonService
{
    public Task Save(CreateDeliveryPersonModel model);
    public Task<bool> UpdateDriverLicenseImage(string newDriverLicenseImage, string identifier);
}