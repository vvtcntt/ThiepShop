using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IProductCheckRepository : IRepository<ProductCheck>
    {

    }
    public class ProductCheckRepository:RepositoryBase<ProductCheck>,IProductCheckRepository
    {
        public ProductCheckRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
