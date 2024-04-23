using Microsoft.AspNetCore.Mvc;
using MyAccount.Contracts;
using MyAccount.Data;
using MyAccount.Models;
using MyAccount.ViewModels;

namespace MyAccount.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["lstStudents"] = await _studentRepository.GetAllAsync();

            return View();
        }

        public async Task<IActionResult> ManageStudent(int id)
        {
            AddOrUpdateStudentVM studentProfile = new AddOrUpdateStudentVM();
            if (id > 0)
            {
                var student = await _studentRepository.GetAsync(id);
                studentProfile.Name = student.Name;
                studentProfile.Id = student.Id;
                studentProfile.ProfilePic = student.ProfilePic;
                //ModelState.Remove("ProfilePic");
            }

            return View(studentProfile);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateStudent(AddOrUpdateStudentVM model)
        {
            if (model.Id > 0)
            {
                ModelState.Remove("ProfilePic");
            }
            StudentProfile studentProfile = new StudentProfile();
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (model.ProfilePic != null && model.ProfilePic.Length > 0)
                {
                    String path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    // Generate a unique filename using GUID
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePic.FileName;
                    String FileNameWithPath = Path.Combine(path, uniqueFileName);

                    studentProfile.ProfilePic = uniqueFileName; // Storing only the filename in studentProfile object

                    using (var stream = new FileStream(FileNameWithPath, FileMode.Create))
                    {
                        model.ProfilePic.CopyTo(stream);
                    }
                    studentProfile.Name = model.Name;
                    await _studentRepository.CreateOrUpdateAsync(studentProfile);
                    return RedirectToAction("Index");
                }
            }
            // If we reach here, something went wrong, so return the same view with validation er   rors
            return View(model);
        }
    }
}
