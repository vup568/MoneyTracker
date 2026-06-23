namespace FinanceTracker.DTOs
{
    public class TransactionDto
    {
        public string TransactionName { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
 
    }
}