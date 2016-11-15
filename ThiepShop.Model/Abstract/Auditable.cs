using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        [Required]
        [MaxLength(200)]
        public string Name { set; get; }

        public DateTime DateCreate { set; get; }
        public bool Active { set; get; }
        public int idUser { set; get; }
        public int Ord { set; get; }
    }
}