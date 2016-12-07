using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ThiepShop.Data.Repositories
{
    public interface IGroupProductRepository : IRepository<GroupProduct>
    {
        IEnumerable<GroupProduct> GetByAlias(string alias);
        string Getords(string id);
    }

    public class GroupProductRepository : RepositoryBase<GroupProduct>, IGroupProductRepository
    {
        public GroupProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<GroupProduct> GetByAlias(string alias)
        {
            return this.DbContext.GroupProducts.Where(x => x.Alias == alias);
        }

        public string Getords(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                int ids = int.Parse(id);
                return this.DbContext.GroupProducts.Where(p => p.Active == true && p.ParentID==ids).DefaultIfEmpty().Max(r => r == null ? 0 : r.Ord + 1).ToString();

            }
            else
            {
                return this.DbContext.GroupProducts.Where(p => p.Active == true).DefaultIfEmpty().Max(r => r == null ? 0 : r.Ord + 1).ToString();

            }
        }
    }
}