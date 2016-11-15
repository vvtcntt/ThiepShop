using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IRegisterRepository : IRepository<Register>
    {
    }
   public class RegisterRepository:RepositoryBase<Register>, IRegisterRepository
    {
        public RegisterRepository(IDbFactory dbFactory):base(dbFactory){ }
    }
}
