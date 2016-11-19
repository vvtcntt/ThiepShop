using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiepShop.Web.Models
{
    public class ConnectColorProductViewModel
    {
        public int id { set; get; }

        public int idColor { set; get; }

       
        public virtual ColorProductViewModel ColorProducts { set; get; }

        public int idPro { set; get; }
 
        public virtual ProductViewModel Products { set; get; }
    }
}