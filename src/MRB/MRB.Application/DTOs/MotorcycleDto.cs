namespace MRB.Application.DTOs;

public record MotorcycleDto(
    string Identificador,
    short Ano,
    string Modelo,
    string Placa);