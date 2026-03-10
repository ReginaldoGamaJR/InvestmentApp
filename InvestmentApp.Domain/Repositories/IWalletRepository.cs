using InvestmentApp.Domain.Entities;
namespace InvestmentApp.Domain.Repositories
{
    public interface IWalletRepository
    {
            Task<Wallet?> GetByIdAsync(int id);
            Task<IEnumerable<Wallet>> GetByUserIdAsync(int userId);
            Task AddAsync(Wallet wallet);
            Task UpdateAsync(Wallet wallet);
    }
}
