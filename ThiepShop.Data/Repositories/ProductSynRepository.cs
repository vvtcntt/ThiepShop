using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace SHOP.Data.Repositories
{
    public interface IProductSynRepository : IRepository<ProductSyn> { }

    public class ProductSynRepository : RepositoryBase<ProductSyn>, IProductSynRepository
    {
        public ProductSynRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}