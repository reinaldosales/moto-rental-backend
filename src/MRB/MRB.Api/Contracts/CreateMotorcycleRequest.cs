using System.ComponentModel.DataAnnotations;

namespace MRB.Api.Contracts;

public class CreateMotorcycleRequest
{
    [Required, MinLength(1)]
    public string Identificador { get; set; }
    
    [Required]
    public short Ano { get; set; }
    
    [Required, MinLength(1)]
    public string Modelo { get; set; }
    
    [Required, MinLength(1)]
    public string Placa { get; set; }
}