using System.ComponentModel.DataAnnotations;
using MRB.Domain.Enums;

namespace MTB.Api.Contracts;

public class CreateDeliveryPersonRequest
{
    [Required]
    public string Identificador { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Cnpj { get; set; }
    
    [Required]
    public DateTime Data_Nascimento { get; set; }
    
    [Required]
    public string Numero_Cnh { get; set; }
    
    [Required]
    public DriverLicense Tipo_Cnh { get; set; }
    
    [Required]
    public string? Imagem_Cnh { get; set; }
}