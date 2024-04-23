using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAccount.Models
{
    public class user
    {
        [DefaultValue(0)]
        public string Id { get; set; }

        [Required(ErrorMessage ="Please Enter a valid email address")]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
