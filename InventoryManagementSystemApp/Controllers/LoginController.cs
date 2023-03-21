using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.IService;
using InventoryManagementSystemInfrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new AppUser());
        }

    }
}
