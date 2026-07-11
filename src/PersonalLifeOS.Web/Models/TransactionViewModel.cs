using System;

namespace PersonalLifeOS.Web.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string TransactionName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public string? Note { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
