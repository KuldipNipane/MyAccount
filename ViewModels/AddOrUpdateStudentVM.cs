using System.ComponentModel.DataAnnotations;

namespace MyAccount.ViewModels
{
    public class AddOrUpdateStudentVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile ProfilePic { get; set; }
    }
}
