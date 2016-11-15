using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblSupport")]
    public class Support : Auditable
    {
        [Required]
        [MaxLength(100)]
        public string Yahoo { set; get; }

        [Required]
        [MaxLength(100)]
        public string Skyper { set; get; }

        [Required]
        [MaxLength(100)]
        public string Mobile { set; get; }

        [Required]
        [MaxLength(100)]
        public string Phone { set; get; }

        [Required]
        [MaxLength(100)]
        public string Mission { set; get; }

        [Required]
        [MaxLength(200)]
        public string Images { set; get; }
    }
}