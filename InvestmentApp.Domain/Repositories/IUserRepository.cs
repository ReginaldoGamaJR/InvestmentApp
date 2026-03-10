using InvestmentApp.Domain.Entities;
namespace InvestmentApp.Domain.Repositories
{
    public interface IUserRepository
    {
            Task<User?> GetByIdAsync(int id);
            Task<User?> GetByEmailAsync(string email);
            Task AddAsync(User user);
            Task UpdateAsync(User user);
            Task<bool> ExistsActiveUserWithEmail(string email);

    }
}
