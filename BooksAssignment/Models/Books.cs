using System.ComponentModel.DataAnnotations;

namespace BooksAssignment.Models
{
    public class BookModel
    {
        [Key]
        
        public int BookId { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Book Name should not be greater than 50 characters")]
        public string BookName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Author Name should not be greater than 50 characters")]
        public string AuthorName { get; set; }

        public string Description { get; set; }
    }
}
