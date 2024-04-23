using Microsoft.AspNetCore.Mvc;
using MyAccount.Data;
using MyAccount.Models;

namespace MyAccount.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbContext _dbContext; 
        public AccountController(ApplicationDbContext context) {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public IActionResult Register(RegisterVM user) 
        { 
            if(ModelState.IsValid)
            {
                _dbContext.Accounts.Add(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public IActionResult Login(user model)
        {
            if (ModelState.IsValid)
            {
             var user = _dbContext.Accounts.FirstOrDefault(u=>u.Email == model.Email);
                if (user != null && user.Password == model.Password) {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult dk()
        {
            return View(new designVM());
        }

    }   
}
