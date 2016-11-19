using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblAgency")]
    public class Agency : Auditable
    {
        public virtual GroupAgency GroupAgency { set; get; }

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
        public string Tag { set; get; }

        public int idMenu { set; get; }

        [Required]
        [MaxLength(200)]
        public string Images { set; get; }

        [Required]
        [MaxLength(200)]
        public string Address { set; get; }

        [Required]
        [MaxLength(100)]
        public string Mobile { set; get; }

        [Required]
        [MaxLength(100)]
        public string People { set; get; }

        [Required]
        [MaxLength(100)]
        public string Email { set; get; }

        [Required]
        [MaxLength(500)]
        public string Tabs { set; get; }
    }
}