namespace InvestmentApp.Application.DTOs.Requests;

public record CreateWalletRequest
{
    public string Name { get; init; } = string.Empty;
}