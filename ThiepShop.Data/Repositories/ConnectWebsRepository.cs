using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IConnectWebsRepository : IRepository<ConnectWebs> { }
   public class ConnectWebsRepository:RepositoryBase<ConnectWebs>, IConnectWebsRepository
    {
        public ConnectWebsRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
