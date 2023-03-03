using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IUserService _user;
        private readonly ILoginService _loginService;

        public AppUserController(IUserService user, ILoginService loginService)
        {
            _user = user;
            _loginService = loginService;
        }
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _user.Get(id);
                return View(user);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUser user)
        {
            try
            {
                if (!ModelState.IsValid) return View(user);

                AppUser existingUser = await _user.Get(user.Id);

                existingUser.FirstName = user.FirstName;
                existingUser.MiddleName = user.MiddleName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Gender = user.Gender;
                existingUser.UpdatedDate = DateTime.Now;

                await _user.Update(user);
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _user.Get(id);
                _user.Remove(user);
                TempData["Message"] = "Successfully Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
