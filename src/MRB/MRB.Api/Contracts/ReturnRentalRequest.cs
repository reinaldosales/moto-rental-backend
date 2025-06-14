using System.ComponentModel.DataAnnotations;

namespace MTB.Api.Contracts;

public class ReturnRentalRequest
{
    [Required]
    public DateTime Data_Devolucao { get; set; }
}