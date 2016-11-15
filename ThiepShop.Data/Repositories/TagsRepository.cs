using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace SHOP.Data.Repositories
{
    public interface ITagsRepository : IRepository<Tags> { }

    public class TagsRepository : RepositoryBase<Tags>, ITagsRepository
    {
        public TagsRepository(IDbFactory dbFacroty) : base(dbFacroty)
        {
        }
    }
}