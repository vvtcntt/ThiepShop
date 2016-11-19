using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblNews")]
    public class News : Auditable
    {
        [ForeignKey("id")]
        public virtual GroupNews GroupNews { set; get; }

        public int idCate { set; get; }

        [Required]
        [MaxLength(200)]
        public string Title { set; get; }

        [Required]
        [MaxLength(500)]
        public string Description { set; get; }

        [Required]
        [MaxLength(500)]
        public string Keyword { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        [Required]
        [MaxLength(200)]
        public string Images { set; get; }

        public bool ViewHomes { set; get; }

        [Required]
        [MaxLength(200)]
        public string Tag { set; get; }

        [Required]
        [MaxLength(500)]
        public string Tabs { set; get; }
    }
}