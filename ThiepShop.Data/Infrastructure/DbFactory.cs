using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiepShop.Data.Infrastructure;
using ThiepShop.Data.Infrastructure;

namespace ThiepShop.Data.Infrastructure
{
    class DbFactory:Disposable,IDbFactory
    {
        private ThiepShopDbContext dbContext;
        public ThiepShopDbContext Init()
        {
            return dbContext ?? (dbContext = new ThiepShopDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                base.DisposeCore();
        }
    }
}
