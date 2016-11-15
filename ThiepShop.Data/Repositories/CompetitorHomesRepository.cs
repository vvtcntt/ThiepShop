﻿using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.Data.Repositories
{
    public interface ICompetitorHomesRepository : IRepository<CompetitorHomes>
    {

    }
    public class CompetitorHomesRepository:RepositoryBase<CompetitorHomes>, ICompetitorHomesRepository
    {
        public CompetitorHomesRepository(IDbFactory dbfactory ):base(dbfactory)
        {

        }
    }
}
