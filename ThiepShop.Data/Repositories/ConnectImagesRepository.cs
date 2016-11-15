using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IConnectImagesRepository : IRepository<ConnectImages> { }
    public class ConnectImagesRepository:RepositoryBase<ConnectImages>
    {
        public ConnectImagesRepository(IDbFactory dbFactory):base(dbFactory)
        {  }
    }
}
