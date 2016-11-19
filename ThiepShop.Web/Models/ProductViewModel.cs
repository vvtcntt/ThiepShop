using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiepShop.Web.Models
{
    public class ProductViewModel
    {
        public int id { set; get; }


        public string Name { set; get; }

        public DateTime DateCreate { set; get; }
        public bool Active { set; get; }
        public int idUser { set; get; }
        public int Ord { set; get; }
        public virtual GroupProductViewModel GroupProduct { set; get; }

        public int idCate { set; get; }

     
        public string Code { set; get; }

      
        public string Title { set; get; }

      
        public string Description { set; get; }

   
        public string Keyword { set; get; }

   
        public string Content { set; get; }

  
        public string Info { set; get; }

        public string Parameter { set; get; }

        public string Tag { set; get; }

        public string ImageLinkThumb { set; get; }

        public string ImageLinkDetail { set; get; }
        public string MoreImages { set; get; }
        public int Price { set; get; }

        public string PriceString { set; get; }

        public int PriceSale { set; get; }

  
        public string PriceSaleString { set; get; }

        public bool Vat { set; get; }

        public string Warranty { set; get; }

        
        public string Address { set; get; }

        public bool Transport { set; get; }

      
        public string Access { set; get; }

     
        public string Sale { set; get; }

     
        public string Note { set; get; }

      
        public string Size { set; get; }

        public string ImageSale { set; get; }

        public bool Status { set; get; }
        public bool ProductSale { set; get; }
        public bool Priority { set; get; }
        public bool New { set; get; }
        public bool ViewHomes { set; get; }
        public int Visit { set; get; }

    
        public string Tags { set; get; }

        public int idVideo { set; get; }
        public virtual IEnumerable<ConnectColorProductViewModel> ConnectColorProducts { set; get; }
        public virtual IEnumerable<ConnectCriteriaViewModel> ConnectCriterias { set; get; }

    }
}