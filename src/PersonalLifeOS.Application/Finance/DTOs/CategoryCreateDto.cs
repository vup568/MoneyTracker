using System.ComponentModel.DataAnnotations; // Thư viện chứa các luật Validation
namespace PersonalLifeOS.Application.Finance.DTOs
{
    public class CategoryCreateDto
    {
        //User do not need send Id because id is Identity
        //just send name and Description => validate these using DataAnnotations
        [Required(ErrorMessage = "Category Name is required")]
        [MaxLength(100, ErrorMessage = "Category Name cannot exceed 100 characters.")]
        public string CategoryName {get; set;} = string.Empty;

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? CategoryDescription{get; set;}


    }
}
