using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace ThiepShop.Data.Repositories
{
    public interface IManufacturesRepository : IRepository<Manufactures> { }

    public class ManufacturesRepository : RepositoryBase<Manufactures>, IManufacturesRepository
    {
        public ManufacturesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}