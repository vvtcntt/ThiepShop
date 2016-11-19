using ThiepShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblCompetitorLink")]
    public class CompetitorLink : Auditable
    {
        public int idHomes { set; get; }

        [ForeignKey("idHomes")]
        public virtual CompetitorHomes CompetitorHomes { set; get; }

        public int idCompetitor { set; get; }

        [ForeignKey("idCompetitor")]
        public virtual Competitor Competitors { set; get; }

        [Required]
        [MaxLength(200)]
        public string Url { set; get; }
    }
}