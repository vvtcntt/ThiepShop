using System;
using System.Collections.Generic;

namespace ThiepShop.Web.Models
{
    public class GroupProductViewModel
    {
        public int id { set; get; }

        public string Name { set; get; }

        public DateTime DateCreate { set; get; }
        public bool Active { set; get; }
        public int idUser { set; get; }
        public int Ord { set; get; }
        public virtual IEnumerable<ProductViewModel> Products { set; get; }
        public virtual IEnumerable<ProductCheckViewModel> ProductChecks { set; get; }

        public int? ParentID { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public string Keyword { set; get; }

        public string Content { set; get; }

        public string Tag { set; get; }

        public int Level { set; get; }
        public bool Priority { set; get; }

        public string Images { set; get; }

        public string Background { set; get; }

        public string iCon { set; get; }

        public string Color { set; get; }

        public string Alias { set; get; }
    }
}