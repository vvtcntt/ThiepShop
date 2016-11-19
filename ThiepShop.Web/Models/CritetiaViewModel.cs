using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiepShop.Web.Models
{
    public class CritetiaViewModel
    {
        public int id { set; get; }


        public string Name { set; get; }

        public DateTime DateCreate { set; get; }
        public bool Active { set; get; }
        public int idUser { set; get; }
        public int Ord { set; get; }
        public int idCate { set; get; }
        public bool Priority { set; get; }
        public bool Style { set; get; }
        public virtual IEnumerable<ConnectCriteriaViewModel> ConnectCriterias { set; get; }

    }
}