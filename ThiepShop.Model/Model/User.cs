using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        [Required]
        [MaxLength(100)]
        public string FullName { set; get; }

        [Required]
        [MaxLength(100)]
        public string UserName { set; get; }

        [Required]
        [MaxLength(200)]
        public string Password { set; get; }

        public int Gender { set; get; }

        [Required]
        [MaxLength(100)]
        public string Email { set; get; }

        [Required]
        [MaxLength(100)]
        public string Phone { set; get; }

        [Required]
        [MaxLength(100)]
        public string Address { set; get; }

        public int idModule { set; get; }
        public bool Active { set; get; }
        public int idUser { set; get; }
        public int Ord { set; get; }

        public DateTime DateCreate { set; get; }
    }
}