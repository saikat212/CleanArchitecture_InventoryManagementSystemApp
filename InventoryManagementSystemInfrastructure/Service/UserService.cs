using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.DataContext;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemInfrastructure.Service
{
    public class UserService : BaseService<AppUser>, IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AppUser> CheckIfExist(string userName)
        {
            var user = await dbContext.AppUsers.FirstOrDefaultAsync(item => item.UserName ==userName);
            return user;
        }
    }
}
