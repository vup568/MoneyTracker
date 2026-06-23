using System.ComponentModel.DataAnnotations;
using FinanceTracker.Models;

namespace FinanceTracker.DTOs
{
    public class TransactionCreateDto
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction Date is required.")]
        public DateTime TransactionDate { get; set; }

        [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Transaction Type is required.")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
    }
}
