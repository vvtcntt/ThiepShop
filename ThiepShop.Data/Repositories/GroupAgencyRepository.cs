using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IGroupAgencyRepository : IRepository<GroupAgency> { }
 public class GroupAgencyRepository:RepositoryBase<GroupAgency>, IGroupAgencyRepository
    {
        public GroupAgencyRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
