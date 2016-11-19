using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblCompetitor")]
    public class Competitor : Auditable
    {
        [Required]
        [MaxLength(200)]
        public string Code { set; get; }

        [Required]
        [MaxLength(300)]
        public string Website { set; get; }

        public virtual IEnumerable<CompetitorLink> CompetitorLinks { set; get; }
    }
}