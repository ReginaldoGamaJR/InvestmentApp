using InvestmentApp.Application.DTOs.Requests;
namespace InvestmentApp.Application.Interfaces;

public interface IRegisterUserUseCase
{
    Task ExecuteAsync(RegisterUserRequest request);
}