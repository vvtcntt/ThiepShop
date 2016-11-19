using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;

namespace ThiepShop.Data.Repositories
{
    public interface IProductSaleRepository : IRepository<ProductSale> { }

    public class ProductSaleRepository : RepositoryBase<ProductSale>
    {
        public ProductSaleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}