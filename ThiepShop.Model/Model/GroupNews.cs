using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblGroupNews")]
    public class GroupNews : Auditable
    {
        public int ParentID { set; get; }
        public virtual IEnumerable<News> News { set; get; }

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

        public bool Index { set; get; }

        [Required]
        [MaxLength(200)]
        public string Images { set; get; }
    }
}