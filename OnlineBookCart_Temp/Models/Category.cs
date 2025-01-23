using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Online_Book_Cart_Temp.Models
{
    //Create class for database table and their columns
    public class Category
    {
        [Key] // Key value for database 
        public int Id { get; set; }
        [Required] // Set required field
        [MaxLength(30, ErrorMessage = "Display name should be less than 30 characters")] //To set max length of Category name
        [DisplayName("Category Name")] // Set display name
        public string Name { get; set; }
        [DisplayName("Display Order")]  // Set display name
        [Range(1, 100, ErrorMessage = "Display order must be between 1-100")]  // Add to set range of display order
        public int DisplayOrder { get; set; }
    }
}
