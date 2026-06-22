namespace FinanceTracker.Models
{
    public enum TransactionType
    {
        Income = 1,
        Expense = 2
    }

    public class Transaction
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Note { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
