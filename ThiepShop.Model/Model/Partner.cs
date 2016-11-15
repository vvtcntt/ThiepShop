using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblPartner")]
    public class Partner : Auditable
    {
        [Required]
        [MaxLength(200)]
        public string Address { set; get; }

        [Required]
        [MaxLength(200)]
        public string Mobile { set; get; }

        [Required]
        [MaxLength(100)]
        public string Hotline { set; get; }

        [Required]
        [MaxLength(100)]
        public string Email { set; get; }
    }
}