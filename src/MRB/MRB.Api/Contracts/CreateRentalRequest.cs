using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MTB.Api.Contracts;

public class CreateRentalRequest
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