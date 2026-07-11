using System.ComponentModel.DataAnnotations;
using PersonalLifeOS.Domain.Finance;

namespace PersonalLifeOS.Application.Finance.DTOs
{
    public class TransactionCreateDto
    {
        [Required(ErrorMessage = "Transaction Title is required.")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

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
