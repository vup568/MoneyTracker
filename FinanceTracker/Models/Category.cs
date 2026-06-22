namespace FinanceTracker.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }

        public ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();

    }
}
