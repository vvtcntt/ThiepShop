using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace ThiepShop.Data.Repositories
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