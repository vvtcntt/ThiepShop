using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IHotlineRepository : IRepository<Hotline> { }
    public class HotlineRepository:RepositoryBase<Hotline>
    {
        public HotlineRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
