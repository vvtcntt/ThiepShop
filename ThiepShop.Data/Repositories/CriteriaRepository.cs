using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface ICriteriaRepository : IRepository<Criteria> { }
    public class CriteriaRepository:RepositoryBase<Criteria>, ICriteriaRepository
    {
        public CriteriaRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
