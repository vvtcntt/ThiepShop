using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IGroupNewsRepository : IRepository<GroupNews>
    {

    }
    public class GroupNewsRepository:RepositoryBase<GroupNews>,IGroupNewsRepository
    {
        public GroupNewsRepository(IDbFactory dbFacroty):base(dbFacroty)
        {

        }
    }
}
