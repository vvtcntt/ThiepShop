using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IConfigRepository : IRepository<Config> { }
    public class ConfigRepository:RepositoryBase<Config>, IConfigRepository
    {
        public ConfigRepository (IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
