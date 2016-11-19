using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IColorProductRepository : IRepository<ColorProduct> { }
    class ColorProductRepository:RepositoryBase<ColorProduct>, IColorProductRepository
    {
        public ColorProductRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
