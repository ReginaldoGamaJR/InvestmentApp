namespace InvestmentApp.Application.DTOs.Responses;

public record LoginResponse(
    string Name,
    string Token
);