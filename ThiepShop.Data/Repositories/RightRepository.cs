using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace SHOP.Data.Repositories
{
    public interface IRightRepository : IRepository<Right> { }

    public class RightRepository : RepositoryBase<Right>, IRightRepository
    {
        public RightRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}