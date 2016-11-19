using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblConnectColorProduct")]
    public class ConnectColorProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idColor { set; get; }

        [ForeignKey("idColor")]
        public virtual ColorProduct ColorProducts { set; get; }

        public int idPro { set; get; }

        [ForeignKey("idPro")]
        public virtual Product Products { set; get; }
    }
}