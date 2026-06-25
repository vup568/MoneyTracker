namespace FinanceTracker.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string TransactionName { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Note { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}