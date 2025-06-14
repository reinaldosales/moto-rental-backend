using System.ComponentModel.DataAnnotations;

namespace MTB.Api.Contracts;

public class UpdateDeliveryPersonDriverLicenseRequest
{
    [Required]
    public string Imagem_Cnh { get; set; }
}