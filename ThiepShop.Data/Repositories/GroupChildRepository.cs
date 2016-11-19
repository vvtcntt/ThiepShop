using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace ThiepShop.Data.Repositories
{
    public interface IGroupChildRepository : IRepository<GroupChild> { }

    public class GroupChildRepository : RepositoryBase<GroupChild>, IGroupChildRepository
    {
        public GroupChildRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}