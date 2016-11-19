using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{public interface IGroupImageRepository : IRepository<GroupImage> { }
    public class GroupImageRepository:RepositoryBase<GroupImage>, IGroupImageRepository
    {
        public GroupImageRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
