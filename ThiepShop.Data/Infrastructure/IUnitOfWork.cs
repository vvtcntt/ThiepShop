using System;
using System.Collections.Generic;
namespace ThiepShop.Data.Infrastructure
{

    public interface IUnitOfWork
    {
        void Commit();
    }

}
