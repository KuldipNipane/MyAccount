using Microsoft.AspNetCore.Mvc;
using MyAccount.Models;

namespace MyAccount.Controllers
{
    public class FileuploadController : Controller
    {
        private readonly string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload");
        public IActionResult Index()
        {
            // Create Directory
            bool dirExists = Directory.Exists(rootPath);

            if (!dirExists)
                Directory.CreateDirectory(rootPath);

            List<string> imageNames = Directory.GetFiles(rootPath).Select(Path.GetFileName).ToList();
            ViewBag.Images = imageNames;
            return View();
        }

        [HttpPost]
        public IActionResult MultipleFileSave()
        {
            var model = new MultipleFileUpload();
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                if (file != null)
                {
                    String path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    model.FileName = Guid.NewGuid().ToString() + file.FileName;
                    String FileNameWithPath = Path.Combine(path, model.FileName);
                    using (var steam = new FileStream(FileNameWithPath, FileMode.Create))
                    {
                        file.CopyTo(steam);
                    }
                    model.IsSuccess = true;
                    model.Message = "File Uploaded SuccessFully !";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
