namespace InvestmentApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; protected set; } = false;
        public void UpdateTimestamps()
        {
            UpdatedAt = DateTime.UtcNow;
        }
        public void Activate()
        {
            IsActive = true;
            UpdateTimestamps();
        }
       public void Deactivate() {
            IsActive = false;
            UpdateTimestamps();
        }
    }
}
