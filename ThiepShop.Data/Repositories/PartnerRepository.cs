using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IPartnerRepository : IRepository<Partner> { }
   public class PartnerRepository:RepositoryBase<Partner>
    {
        public PartnerRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
