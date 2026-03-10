using InvestmentApp.Application.DTOs.Requests;
using InvestmentApp.Application.DTOs.Responses;

namespace InvestmentApp.Application.Interfaces;

public interface ILoginUserUseCase
{
    Task<LoginResponse> ExecuteAsync(LoginRequest request);
}