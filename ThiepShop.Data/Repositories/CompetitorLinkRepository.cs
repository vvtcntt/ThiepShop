using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface ICompetitorLinkRepository : IRepository<CompetitorLink>
    {

    }
   public class CompetitorLinkRepository:RepositoryBase<CompetitorLink>, ICompetitorLinkRepository
    {
        public CompetitorLinkRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
