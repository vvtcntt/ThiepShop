using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IMapsRepository : IRepository<Maps> { }
    public class MapsRepository:RepositoryBase<Maps>, IMapsRepository
    {
        public MapsRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
