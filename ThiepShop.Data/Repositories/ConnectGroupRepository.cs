using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IConnectGroupRepository : IRepository<ConnectGroup> { }
   public class ConnectGroupRepository:RepositoryBase<ConnectGroup>, IConnectGroupRepository
    {
        public ConnectGroupRepository(IDbFactory dbFactory):base(dbFactory)
        {  }
    }
}
