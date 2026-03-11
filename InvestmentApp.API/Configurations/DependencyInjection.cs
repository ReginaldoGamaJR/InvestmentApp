using InvestmentApp.Application.Interfaces;
using InvestmentApp.Application.UseCases;
using InvestmentApp.Application.UseCases.User;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Domain.Repositories;
using InvestmentApp.Infrastructure.Persistence;
using InvestmentApp.Infrastructure.Repositories;
using InvestmentApp.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace InvestmentApp.API.Extensions;

public static class DependencyInjection
{

    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuração do Banco de Dados
        services.AddDbContext<InvestmentDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // Camada de Application (Use Cases)
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();

        // Camada de Infrastructure (Serviços Externos)
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWalletRepository, WalletRepository>();

        return services;
    }
}