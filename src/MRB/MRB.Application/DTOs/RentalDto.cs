namespace MRB.Application.DTOs;

public record RentalDto(
    string Identificador,
    decimal Valor_Diaria,
    string Entregador_Id,
    string Moto_Id,
    DateTime Data_Inicio,
    DateTime Data_Termino,
    DateTime? Data_Previsao_Termino,
    DateTime? Data_Devolucao
);