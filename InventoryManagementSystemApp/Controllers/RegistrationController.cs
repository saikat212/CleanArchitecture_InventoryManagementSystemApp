using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService _user;
        private readonly ILoginService _loginService;

        public RegistrationController(IUserService user, ILoginService loginService)
        {
            _user = user;
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AppUser());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser user)
        {
            try
            {
                if (!ModelState.IsValid) return View(user);
                AppUser existingUser = await _user.CheckIfExist(user.UserName);
                if (existingUser != null)
                {
                    TempData["Message"] = "User name is already exist";
                    return View(user);
                }
                await _user.Save(user);
                TempData["Message"] = "Successful Sign Up Done";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
