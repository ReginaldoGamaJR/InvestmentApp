using InvestmentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentApp.Infrastructure.Persistence;

public class InvestmentDbContext : DbContext
{
    public InvestmentDbContext(DbContextOptions<InvestmentDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);

            entity.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.Street).HasColumnName("Street");
                address.Property(a => a.Number).HasColumnName("Number");
                address.Property(a => a.Neighborhood).HasColumnName("Neighborhood");
                address.Property(a => a.City).HasColumnName("City");
                address.Property(a => a.State).HasColumnName("State");
                address.Property(a => a.ZipCode).HasColumnName("ZipCode");
                address.Property(a => a.Country).HasColumnName("Country");
                address.Property(a => a.AdditionalInfo).HasColumnName("AdditionalInfo");
            });
        });


    }
}