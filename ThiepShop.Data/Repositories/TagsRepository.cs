using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace ThiepShop.Data.Repositories
{
    public interface ITagsRepository : IRepository<Tags> { }

    public class TagsRepository : RepositoryBase<Tags>, ITagsRepository
    {
        public TagsRepository(IDbFactory dbFacroty) : base(dbFacroty)
        {
        }
    }
}