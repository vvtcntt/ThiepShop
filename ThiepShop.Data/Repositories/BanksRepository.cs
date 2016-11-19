﻿using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IBanksRepository : IRepository<Banks>
    {
    }
    public class BanksRepository: RepositoryBase<Banks>, IBanksRepository
    {
        public BanksRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
