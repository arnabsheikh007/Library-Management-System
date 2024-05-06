using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Managemet_System_API.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AvailableCopies { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int TotalCopies { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
