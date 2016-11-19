using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
        string GetOrds(int idCate);


    }
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) :base(dbFactory)
        {

        }

        public IEnumerable<Product> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products join pt in DbContext.GroupProducts on p.idCate equals pt.id where pt.Tag == tag && p.Active == true select p;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
        public string GetOrds(int idCate)
        {
            return this.DbContext.Products.Where(p => p.Active == true && p.idCate==idCate).DefaultIfEmpty().Max(r => r == null ? 0 : r.Ord + 1).ToString();
        }
    }
}
