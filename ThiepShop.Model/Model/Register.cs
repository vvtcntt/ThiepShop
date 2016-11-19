using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblRegister")]
    public class Register : Auditable
    {
        [Required]
        [MaxLength(200)]
        public string Email { set; get; }

        [Required]
        [MaxLength(100)]
        public string Mobile { set; get; }

        public int idCate { set; get; }
    }
}