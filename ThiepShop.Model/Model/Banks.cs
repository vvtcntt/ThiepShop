using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblBanks")]
    public class Banks : Auditable
    {
        [Required]
        [MaxLength(200)]
        public string Address { set; get; }

        [Required]
        [MaxLength(200)]
        public string NameBank { set; get; }

        [Required]
        [MaxLength(100)]
        public string NumberBank { set; get; }

        [Required]
        [MaxLength(200)]
        public string Images { set; get; }
    }
}