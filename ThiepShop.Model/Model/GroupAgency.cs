using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("GroupAgency")]
    public class GroupAgency : Auditable
    {
        public virtual IEnumerable<Agency> Agencys { set; get; }

        [Required]
        [MaxLength(200)]
        public string Title { set; get; }

        [Required]
        [MaxLength(500)]
        public string Description { set; get; }

        [Required]
        [MaxLength(500)]
        public string Keyword { set; get; }

        [Required]
        [MaxLength(200)]
        public string Tag { set; get; }

        [Required]
        [MaxLength(100)]
        public string Level { set; get; }
    }
}