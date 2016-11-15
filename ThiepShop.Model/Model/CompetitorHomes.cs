using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("CompetitorHomes")]
    public class CompetitorHomes : Auditable
    {
        [Required]
        [MaxLength(200)]
        public string CodeProduct { set; get; }

        public virtual IEnumerable<CompetitorLink> CompetitorLinks { set; get; }
    }
}