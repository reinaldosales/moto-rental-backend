using System.ComponentModel.DataAnnotations;

namespace MRB.Api.Contracts;

public class UpdateMotorcyleLicencePlateRequest
{
    [Required, MinLength(1)]
    public string Placa { get; set; }
}