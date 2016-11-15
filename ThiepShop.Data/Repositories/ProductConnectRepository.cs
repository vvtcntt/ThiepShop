using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IProductConnectRepository : IRepository<ProductConnect> { }
   public class ProductConnectRepository:RepositoryBase<ProductConnect>, IProductConnectRepository
    {
        public ProductConnectRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
