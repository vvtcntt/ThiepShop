using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiepShop.Web.Models
{
    public class ConnectCriteriaViewModel
    {
        public int id { set; get; }

        public int idCre { set; get; }

 
        public virtual CriteriaViewModel Criterias { set; get; }

        public int idpd { set; get; }
 
        public virtual ProductViewModel Products { set; get; }
    }
}