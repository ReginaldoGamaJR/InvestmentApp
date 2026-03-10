using InvestmentApp.Domain.ValueObjects;

namespace InvestmentApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Wallet> Wallets { get; private set; } = new List<Wallet>();

        public User(string name, string email, string passwordHash, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PhoneNumber = phoneNumber;
            Address =  address;
        }

        public void UpdateAddress(Address newAddress)
        {
            Address = newAddress;
            UpdateTimestamps(); 
        }
        protected User() { }
    }
}
