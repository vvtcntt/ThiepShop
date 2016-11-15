using ThiepShop.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblProductSale")]
    public class ProductSale : Auditable
    {
        [Required]
        [MaxLength(500)]
        public string Description { set; get; }

        [Required]
        [MaxLength(1000)]
        public string CodeOne { set; get; }

        [Required]
        [MaxLength(1000)]
        public string CodeTrue { set; get; }

        [Required]
        [MaxLength(1000)]
        public string CodeSale { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        [Required]
        [MaxLength(300)]
        public string Slogan { set; get; }

        [Required]
        [MaxLength(1000)]
        public string TextRun { set; get; }

        public DateTime StartSale { set; get; }

        public DateTime StopSale { set; get; }

        [Required]
        [MaxLength(200)]
        public string ImageBanner { set; get; }

        [Required]
        [MaxLength(200)]
        public string ImageSale { set; get; }

        [Required]
        [MaxLength(200)]
        public string ImageThumb { set; get; }

        [Required]
        [MaxLength(200)]
        public string Tag { set; get; }
    }
}