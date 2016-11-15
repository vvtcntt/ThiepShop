using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblConfig")]
    public class Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(200)]
        public string Title { set; get; }

        [Required]
        [MaxLength(500)]
        public string Desciption { set; get; }

        [Required]
        [MaxLength(500)]
        public string Keywords { set; get; }

        [Required]
        [MaxLength(200)]
        public string Logo { set; get; }

        [Required]
        [MaxLength(200)]
        public string Favicon { set; get; }

        public bool Popup { set; get; }
        public bool PopupSupport { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        [Required]
        [MaxLength(200)]
        public string Name { set; get; }

        [Required]
        [MaxLength(200)]
        public string Address { set; get; }

        [Required]
        [MaxLength(100)]
        public string MobileIN { set; get; }

        [Required]
        [MaxLength(100)]
        public string Mobile { set; get; }

        [Required]
        [MaxLength(100)]
        public string Holine { set; get; }

        [Required]
        [MaxLength(100)]
        public string HolineIN { set; get; }

        [Required]
        [MaxLength(100)]
        public string Email { set; get; }

        [Required]
        [MaxLength(200)]
        public string Slogan { set; get; }

        [Required]
        [MaxLength(100)]
        public string Authorship { set; get; }

        [Required]
        [MaxLength(200)]
        public string FanpageFaceBook { set; get; }

        [Required]
        [MaxLength(200)]
        public string FanpageGoogle { set; get; }

        [Required]
        [MaxLength(200)]
        public string FanpageYoutube { set; get; }

        [Required]
        [MaxLength(100)]
        public string AppFaceBook { set; get; }

        [Required]
        [MaxLength(200)]
        public string Analytics { set; get; }

        [Required]
        [MaxLength(500)]
        public string GoogleMaster { set; get; }

        [Required]
        [MaxLength(1000)]
        public string GeoMeta { set; get; }

        [Required]
        [MaxLength(200)]
        public string DMCA { set; get; }

        [Required]
        [MaxLength(1000)]
        public string CodeChat { set; get; }

        [Required]
        [MaxLength(200)]
        public string BCT { set; get; }

        [Required]
        [MaxLength(200)]
        public string BNI { set; get; }

        [Required]
        [MaxLength(200)]
        public string SKH { set; get; }

        public bool Coppy { set; get; }
        public bool Social { set; get; }

        [Required]
        [MaxLength(100)]
        public string UserEmail { set; get; }

        [Required]
        [MaxLength(100)]
        public string PassEmail { set; get; }

        [Required]
        [MaxLength(100)]
        public string Host { set; get; }

        public int Port { set; get; }

        [Required]
        [MaxLength(100)]
        public string Color { set; get; }

        [Required]
        [MaxLength(100)]
        public string TimeOut { set; get; }

        public int language { set; get; }
    }
}