using InvestmentApp.Application.DTOs.Requests;
namespace InvestmentApp.Application.Interfaces;

public interface ICreateWalletUseCase
{
    Task ExecuteAsync(CreateWalletRequest request, int userId);
}