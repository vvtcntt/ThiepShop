using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblConnectCriteria")]
    public class ConnectCriteria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idCre { set; get; }

        [ForeignKey("idCre")]
        public virtual Criteria Criterias { set; get; }

        public int idpd { set; get; }

        [ForeignKey("idpd")]
        public virtual Product Products { set; get; }
    }
}