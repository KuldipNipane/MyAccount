using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAccount.Models
{
    [Table("Students")]
    public class StudentProfile : BaseEntity
    {
        [StringLength(256)]
        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        [Required]
        public IFormFile ProfilePic { get; set; }
    }
}
