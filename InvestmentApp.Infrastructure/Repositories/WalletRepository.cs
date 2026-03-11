using InvestmentApp.Domain.Entities;
using InvestmentApp.Domain.Repositories;
using InvestmentApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentApp.Infrastructure.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly InvestmentDbContext _context;

    public WalletRepository(InvestmentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Wallet wallet)
    {
        await _context.Wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
    }

    public async Task<Wallet?> GetByIdAsync(int id)
    {
        return await _context.Wallets.FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<IEnumerable<Wallet>> GetByUserIdAsync(int userId)
    {
        return await _context.Wallets
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _context.Wallets.Update(wallet);
        await _context.SaveChangesAsync();
    }
}