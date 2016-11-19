﻿using ThiepShop.Data.Infrastructure;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Data.Repositories
{
    public interface IConnectCriteriaRepository : IRepository<ConnectCriteria> { }
    public class ConnectCriteriaRepository:RepositoryBase<ConnectCriteria>
    {
        public ConnectCriteriaRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
