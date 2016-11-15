using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblConnectNews")]
    public class ConnectNews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idNew { set; get; }
        public int idCate { set; get; }
    }
}