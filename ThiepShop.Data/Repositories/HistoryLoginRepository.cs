using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{public interface IHistoryLoginRepository : IRepository<HistoryLogin> { }
   public class HistoryLoginRepository: RepositoryBase<HistoryLogin>, IHistoryLoginRepository
    {
        public HistoryLoginRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
