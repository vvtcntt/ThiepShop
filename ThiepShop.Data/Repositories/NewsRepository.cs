using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface INewsRepository : IRepository<News>
    {

    }
   public class NewsRepository:RepositoryBase<News>,INewsRepository
    {
        public NewsRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
