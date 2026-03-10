using InvestmentApp.Domain.Entities;
namespace InvestmentApp.Domain.Repositories
{
    public interface ICategoryRepository
    {
            Task<IEnumerable<Category>> GetByUserIdAsync(int userId);
            Task<IEnumerable<Category>> GetAllAsync();
            Task AddAsync(Category category);
            Task UpdateAsync(Category category);
    }
}
