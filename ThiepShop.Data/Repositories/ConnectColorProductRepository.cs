using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IConnectColorProductRepository : IRepository<ConnectColorProduct> { }
    public class ConnectColorProductRepository:RepositoryBase<ConnectColorProduct>, IConnectColorProductRepository
    {
        public ConnectColorProductRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
