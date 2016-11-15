using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblVideo")]
    public class Video : Auditable
    {
        [Required]
        [MaxLength(500)]
        public string code { set; get; }

        public bool AutoPlay { set; get; }
    }
}