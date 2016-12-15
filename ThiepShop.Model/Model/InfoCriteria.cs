using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblInfoCriteria")]
    public class InfoCriteria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idCri { set; get; }

        [Required]
        [MaxLength(200)]
        public string Name { set; get; }

        public string Url { set; get; }

        public int? type { set; get; }
        public int Ord { set; get; }
        public bool Active { set; get; }
    }
}