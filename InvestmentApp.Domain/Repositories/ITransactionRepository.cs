using InvestmentApp.Domain.Entities;
namespace InvestmentApp.Domain.Repositories
{
    public interface ITransactionRepository
    {    
        Task<Transaction?> GetByIdAsync(int id);
        Task<IEnumerable<Transaction>> GetByWalletIdAsync(int walletId);
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetByPeriodAsync(int walletId, DateTime start, DateTime end);
    }
}
