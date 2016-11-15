using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblProductTags")]
    public class ProductTags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idProduct { set; get; }
        public string idTags { set; get; }

        //[ForeignKey("idProduct")]
        //public virtual Product Products { set; get; }

      
    }
}