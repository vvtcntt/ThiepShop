using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblColorProduct")]
    public class ColorProduct : Auditable
    {
        [Required]
        [MaxLength(200)]
        public string Image { set; get; }

        public virtual IEnumerable<ConnectColorProduct> ConnectColorProducts { set; get; }
    }
}