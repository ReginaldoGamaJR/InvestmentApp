using InvestmentApp.Domain.Entities;

namespace InvestmentApp.Application.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}