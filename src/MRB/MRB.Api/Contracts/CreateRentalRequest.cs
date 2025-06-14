using System.ComponentModel.DataAnnotations;
using MRB.Domain.Enums;

namespace MTB.Api.Contracts;

public class CreateRentalRequest
{
    [Required]
    public string Entregador_id { get; set; }
    
    [Required]
    public string Moto_id { get; set; }
    
    [Required]
    public DateTime Data_Inicio { get; set; }
    
    [Required]
    public DateTime Data_Termino { get; set; }
    
    [Required]
    public DateTime Data_Previsao_Termino { get; set; }
    
    [Required]
    public RentalPlan plano { get; set; }
}