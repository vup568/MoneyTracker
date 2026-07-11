namespace PersonalLifeOS.Domain.Finance
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();

    }
}
