using System.ComponentModel.DataAnnotations;

namespace MRB.Api.Contracts;

public class ReturnRentalRequest
{
    [Required]
    public DateTime Data_Devolucao { get; set; }
}