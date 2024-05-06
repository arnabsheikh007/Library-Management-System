using System.ComponentModel.DataAnnotations;

namespace Library_Managemet_System_API.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
