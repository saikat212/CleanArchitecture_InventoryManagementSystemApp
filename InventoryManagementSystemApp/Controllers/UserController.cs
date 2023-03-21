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

        [HttpGet]
        [Route("Create")]
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
                TempData["Message"] = "Successfully Saved";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }



        // retrieve a user by :id with /api/ user /:id

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _user.GetById(id);

                return View(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // /api/user/:name retrieve a user by :name
        [HttpGet]
        [Route("Details/{name}")]

        public async Task<IActionResult> Details(string name)
        {
            try
            {
                var user = await _user.GetByName(name);
                return View(user);
            }
            catch (Exception)
            {
                throw;
            }
        }







    }
}
