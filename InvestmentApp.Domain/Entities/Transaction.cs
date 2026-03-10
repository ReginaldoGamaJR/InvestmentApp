namespace InvestmentApp.Domain.Entities;

public enum TransactionType
{
    Income = 1,
    Expense = 2
}

public class Transaction : BaseEntity
{
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public TransactionType Type { get; private set; }

    public int WalletId { get; private set; }
    public Wallet Wallet { get; private set; } = null!;

    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public Transaction(string description, decimal amount, DateTime date,
                       TransactionType type, int walletId, int categoryId)
    {
        Description = description;
        Amount = amount;
        TransactionDate = date;
        Type = type;
        WalletId = walletId;
        CategoryId = categoryId;
    }
}