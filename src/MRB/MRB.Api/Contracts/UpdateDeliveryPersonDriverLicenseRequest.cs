using System.ComponentModel.DataAnnotations;

namespace MRB.Api.Contracts;

public class UpdateDeliveryPersonDriverLicenseRequest
{
    [Required]
    public string Imagem_Cnh { get; set; }
}