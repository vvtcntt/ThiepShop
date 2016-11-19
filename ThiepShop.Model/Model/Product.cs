using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblProduct")]
    public class Product : Auditable
    {
        [ForeignKey("idCate")]
        public virtual GroupProduct GroupProduct { set; get; }

        public int? idCate { set; get; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Code { set; get; }

        [Required]
        [MaxLength(200)]
        public string Title { set; get; }

        [Required]
        [MaxLength(300)]
        public string Description { set; get; }

        [MaxLength(500)]
        public string Keyword { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        [Column(TypeName = "ntext")]
        public string Info { set; get; }

        [Column(TypeName = "ntext")]
        public string Parameter { set; get; }

        [MaxLength(500)]
        public string Tag { set; get; }

        [MaxLength(200)]
        public string ImageLinkThumb { set; get; }

        [MaxLength(200)]
        public string ImageLinkDetail { set; get; }
        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }
        [Required]
        public int? Price { set; get; }

         [MaxLength(700)]
        public string PriceString { set; get; }

        [Required]
        public int? PriceSale { set; get; }

        [MaxLength(700)]
        public string PriceSaleString { set; get; }

        public bool? Vat { set; get; }

        [Required]
        [MaxLength(50)]
        public string Warranty { set; get; }

        [MaxLength(50)]
        public string Address { set; get; }

        public bool? Transport { set; get; }

         [MaxLength(300)]
        public string Access { set; get; }

        [MaxLength(300)]
        public string Sale { set; get; }

        [MaxLength(300)]
        public string Note { set; get; }

        [MaxLength(200)]
        public string Size { set; get; }

        [MaxLength(200)]
        public string ImageSale { set; get; }

        public bool? Status { set; get; }
        public bool? ProductSale { set; get; }
        public bool? Priority { set; get; }
        public bool? New { set; get; }
        public bool? ViewHomes { set; get; }
        public int? Visit { set; get; }

         [MaxLength(500)]
        public string Tags { set; get; }

        public int? idVideo { set; get; }
        public virtual IEnumerable<ConnectColorProduct> ConnectColorProducts { set; get; }
        public virtual IEnumerable<ConnectCriteria> ConnectCriterias { set; get; }
        //public virtual IEnumerable<ProductTags> ProductTags { set; get; }

    }
}