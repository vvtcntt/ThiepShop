using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblOrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        public int idOrder { set; get; }
        public int idProduct { set; get; }

        [Required]
        [MaxLength(200)]
        public string Name { set; get; }

        public int Quantily { set; get; }
        public float Price { set; get; }
        public float SumPrice { set; get; }
    }
}