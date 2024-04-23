namespace MyAccount.Models
{
    public class ResponseVM
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsResponse { get; set; }
    }
    public class MultipleFileUpload : ResponseVM
    {
        public string FileName { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
