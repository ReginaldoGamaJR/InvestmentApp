using InvestmentApp.Application.DTOs.Requests;
using InvestmentApp.Application.DTOs.Responses;
using InvestmentApp.Application.Interfaces;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Domain.Repositories;

namespace InvestmentApp.Application.UseCases
{
    public class LoginUserUseCase : ILoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginUserUseCase(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null)
            {
                throw new Exception("E-mail ou senha inválidos.");
            }

            var isPasswordValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("E-mail ou senha inválidos.");
            }

            var token = _tokenGenerator.GenerateToken(user);

            return new LoginResponse(user.Name, token);
        }
    }
}