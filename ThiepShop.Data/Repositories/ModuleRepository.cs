using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IModuleRepository : IRepository<Module> { }
    public class ModuleRepository:RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
