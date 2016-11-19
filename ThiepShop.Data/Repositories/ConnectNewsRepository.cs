using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IConnectNewsRepository : IRepository<ConnectNews> { }
    public class ConnectNewsRepository:RepositoryBase<ConnectNews>, IConnectNewsRepository
    {
        public ConnectNewsRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }

}
