using InvestmentApp.Application.DTOs.Requests;
using InvestmentApp.Application.Interfaces;
using InvestmentApp.Domain.Entities;
using InvestmentApp.Domain.Repositories;

namespace InvestmentApp.Application.UseCases;

public class CreateWalletUseCase : ICreateWalletUseCase
{
    private readonly IWalletRepository _walletRepository;
    private readonly IUserRepository _userRepository;
    public CreateWalletUseCase(IWalletRepository walletRepository, IUserRepository userRepository)
    {
        _walletRepository = walletRepository;
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync(CreateWalletRequest request, int userId)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("O nome da carteira não pode ser vazio.");
        }

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }
        var wallet = new Wallet(request.Name, 0m, user);
        await _walletRepository.AddAsync(wallet);
    }
}