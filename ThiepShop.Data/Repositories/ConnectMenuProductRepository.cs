using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{ public interface IConnectMenuProductRepository : IRepository<ConnectMenuProduct> { }
    public class ConnectMenuProductRepository:RepositoryBase<ConnectMenuProduct>, IConnectMenuProductRepository
    {
        public ConnectMenuProductRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
