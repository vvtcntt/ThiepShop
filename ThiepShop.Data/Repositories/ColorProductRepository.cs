using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;


namespace SHOP.Data.Repositories
{
    public interface IColorProductRepository : IRepository<ColorProduct> { }
    class ColorProductRepository:RepositoryBase<ColorProduct>, IColorProductRepository
    {
        public ColorProductRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
