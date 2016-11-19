using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblHistoryLogin")]
    public class HistoryLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        [Required]
        [MaxLength(100)]
        public string FullName { set; get; }

        [Required]
        [MaxLength(100)]
        public string Task { set; get; }

        public int idUser { set; get; }
        public DateTime DateCreate { set; get; }
        public bool Active { set; get; }
    }
}