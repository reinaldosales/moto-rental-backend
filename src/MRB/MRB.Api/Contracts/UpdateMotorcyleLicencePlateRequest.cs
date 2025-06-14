using System.ComponentModel.DataAnnotations;

namespace MTB.Api.Contracts;

public class UpdateMotorcyleLicencePlateRequest
{
    [Required, MinLength(1)]
    public string Placa { get; set; }
}