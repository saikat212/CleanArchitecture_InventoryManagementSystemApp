using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _user;
        private readonly ILoginService _loginService;

        public UserController(IUserService user, ILoginService loginService)
        {
            _user = user;
            _loginService = loginService;
        }

        // show a list of all users in View page 
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userList = await _user.GetAll();
                return View(userList);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
