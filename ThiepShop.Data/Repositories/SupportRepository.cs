using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface ISupportRepository : IRepository<Support> { }
   public class SupportRepository:RepositoryBase<Support>, ISupportRepository
    {
        public SupportRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
