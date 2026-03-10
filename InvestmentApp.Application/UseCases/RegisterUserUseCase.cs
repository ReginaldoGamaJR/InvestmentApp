using InvestmentApp.Application.DTOs.Requests;
using InvestmentApp.Application.Interfaces;
using InvestmentApp.Domain.Repositories;
using InvestmentApp.Domain.ValueObjects;
using InvestmentApp.Domain.Interfaces;
using UserEntity = InvestmentApp.Domain.Entities.User;

namespace InvestmentApp.Application.UseCases.User;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    public RegisterUserUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task ExecuteAsync(RegisterUserRequest request)
    {
        var emailExists = await _userRepository.ExistsActiveUserWithEmail(request.Email!);
        if (emailExists)
        {
            throw new Exception("Este e-mail já está cadastrado no sistema.");
        }
        var passwordHash = _passwordHasher.Hash(request.Password!);
        var address = new Address(
            request.Street ?? "",
            request.Number ?? "", 
            request.Neighborhood ?? "",
            request.City ?? "",
            request.State ?? "",
            request.ZipCode ?? "",
            request.Country ?? "Brasil",
            request.AdditionalInfo ?? "" 
        );

        var user = new UserEntity(
            request.Name!,
            request.Email!,
            passwordHash,
            request.PhoneNumber!,
            address
        );
        await _userRepository.AddAsync(user);
    }
}