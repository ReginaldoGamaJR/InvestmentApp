using System.Transactions;

namespace InvestmentApp.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; } = null!;

        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public Wallet(string name, decimal balance, User user)
        {
            Name = name;
            Balance = balance;
            UserId = user.Id;
            User = user;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0) return; 

            Balance += amount;
            UpdateTimestamps(); 
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance) return; 

            Balance -= amount;
            UpdateTimestamps();
        }
        protected Wallet() { }
    }
}
