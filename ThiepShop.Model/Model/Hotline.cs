using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblHotline")]
    public class Hotline : Auditable
    {
        [Required]
        [MaxLength(100)]
        public string Mobile { set; get; }

        [Required]
        [MaxLength(100)]
        public string Holine { set; get; }
    }
}