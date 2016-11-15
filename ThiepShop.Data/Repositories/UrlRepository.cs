using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace SHOP.Data.Repositories
{
    public interface IUrlRepository : IRepository<Url>
    {
    }

    public class UrlRepository : RepositoryBase<Url>, IUrlRepository
    {
        public UrlRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}