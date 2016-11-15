using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblConnectImages")]
    public class ConnectImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idImg { set; get; }
        public int idCate { set; get; }
    }
}