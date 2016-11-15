﻿using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface IImagesRepository : IRepository<Images> { }
   public class ImagesRepository:RepositoryBase<Images>
    {
        public ImagesRepository(IDbFactory dbFactory):base(dbFactory)
        { }
    }
}
