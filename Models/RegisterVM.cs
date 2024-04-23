using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAccount.Models
{
    public class RegisterVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="not match")]
        public string ConfirmPassword { get; set;}
    }

    public class designVM
    {
        [Key]
        public string EventName { get; set; }
        public string Title  { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string UploadDocument { get; set; }
    }
}
