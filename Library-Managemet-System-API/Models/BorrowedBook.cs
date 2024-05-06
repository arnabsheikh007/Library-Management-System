using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Managemet_System_API.Models
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowID { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        [Required]
        [ForeignKey("Member")]
        public int MemberID { get; set; }
        public Member Member { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public Book Book { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
