using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private ThiepShopDbContext dbContext;
        public ThiepShopDbContext Init()
        {
            return dbContext ?? (dbContext = new ThiepShopDbContext());
        }
        protected override void DisposeCore()
        {
            if(dbContext!=null)
            base.DisposeCore();
        }
    }
}
