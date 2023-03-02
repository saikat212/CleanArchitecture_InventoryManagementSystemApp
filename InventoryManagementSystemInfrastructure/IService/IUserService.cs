using InventoryManagementSystemDomain.Entity;

namespace InventoryManagementSystemInfrastructure.IService
{
    public interface IUserService : IBaseService<AppUser>
    {
        Task<AppUser> CheckIfExist(string userName);
    }
}
