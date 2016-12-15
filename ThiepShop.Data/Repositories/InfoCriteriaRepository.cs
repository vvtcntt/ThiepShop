using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IInfoCriteriaRepository : IRepository<InfoCriteria>
    {
        int Getords();
    }
    public class InfoCriteriaRepository : RepositoryBase<InfoCriteria>, IInfoCriteriaRepository
    {
        public InfoCriteriaRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public int Getords()
        {
            return int.Parse(this.DbContext.InfoCriterias.Where(p => p.Active == true).DefaultIfEmpty().Max(r => r == null ? 0 : r.Ord + 1).ToString());

        }
    }
}
