using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IWebRepository : IRepository<Web>
    {

    }
    public class WebRepository:RepositoryBase<Web>, IWebRepository
    {
        public WebRepository(IDbFactory dbFactory):base(dbFactory)
        {  }
    }
}
