using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IFilesRepository : IRepository<Files> { }
  public  class FilesRepository:RepositoryBase<Files>, IFilesRepository
    {
        public FilesRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
