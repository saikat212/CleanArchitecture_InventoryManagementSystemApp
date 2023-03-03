using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.DataContext;
using InventoryManagementSystemInfrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemInfrastructure.Service
{
    public class LoginService: BaseService<AppUser>, ILoginService
    {
        private readonly ApplicationDbContext dbContext;

        public LoginService(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
