using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace ThiepShop.Data.Repositories
{
    public interface IProductTagsRepository : IRepository<ProductTags> { }

    public class ProductTagsRepository : RepositoryBase<ProductTags>, IProductTagsRepository
    {
        public ProductTagsRepository(IDbFactory dbFacroty) : base(dbFacroty)
        {
        }
    }
}